using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.Data.Entities.DelivtyMethods;
using Store.Data.Entities.Order;
using Store.Repository.Interfaces;
using Store.Repository.Specifications.OrderSpecification;
using Store.Services.Services.BasketService;
using Store.Services.Services.BasketService.Dtos;
using Store.Services.Services.OrderServices.Dto;
using Stripe;

namespace Store.Services.Services.PaymentServices
{
    public class PayemntService : IPayemntService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public PayemntService(IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IBasketService basketService,
            IMapper mapper)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
           _basketService = basketService;
            _mapper = mapper;
        }

        public async Task<OrderDetails> UpdateOrderPaymentIntentSucced(string PaymentIntentId)
        {
            var Specs = new OrderPaymentSpecification(PaymentIntentId);
            var Order = await _unitOfWork.Repository<Orders, Guid>().GetWitSpecificationByIdAsync(Specs);
            if (Order == null)
                throw new Exception("Order Not Esist");
            Order.OrderStates = OrderStates.Delevring;
            _unitOfWork.Repository<Orders, Guid>().Update(Order);
            await _unitOfWork.CompleteAsync();
            await _basketService.DeleteBAsketAsy(Order.BasketId);
            var MappedOrder = _mapper.Map<OrderDetails>(Order);
            return MappedOrder;
        }

        public async Task<CustomerBasketDto> CreateOrUpdatePaymentIntent(CustomerBasketDto Input)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:Secretkey"];
            if (Input is null)
                throw new Exception("Input Is Not Esist");
            var DeliveryMethod = await _unitOfWork.Repository<DeliveryMethods, int>().GetByIdAsync(Input.DelivryMethodId.Value);
            if (DeliveryMethod == null)
                throw new Exception("Delevry Not Add");

            decimal ShippingPrice = DeliveryMethod.Price;
            foreach (var item in Input.BasketItems)
            {
                var Product = await _unitOfWork.Repository<Product, int>().GetByIdAsync(item.ProductId);
                if (item.Price != Product.Price)
                    item.Price = Product.Price;

            }
            var Service = new PaymentIntentService();
            PaymentIntent paymentIntent;
            if (string.IsNullOrEmpty(Input.PayMentIntentId))
            {
                var option = new PaymentIntentCreateOptions
                {
                    Amount = (long)Input.BasketItems.Sum(I => I.Quantity * (I.Price * 100)) + (long)(ShippingPrice * 100),
                    Currency = "Usd",
                    PaymentMethodTypes = new List<string> { "Card" }
                };
                paymentIntent = await Service.CreateAsync(option);
                Input.PayMentIntentId = paymentIntent.Id;
                Input.ClientSecret = paymentIntent.ClientSecret;



            }
            else
            {
                var option = new PaymentIntentUpdateOptions
                {
                    Amount = (long)Input.BasketItems.Sum(I => I.Quantity * (I.Price * 100)) + (long)(ShippingPrice * 100),

                };
                await Service.UpdateAsync(Input.PayMentIntentId,option);
            }
            await _basketService.UpdateBasketAsy(Input);
            return Input;
        }

        public async Task<OrderDetails> UpdateOrderPaymentIntentFaild(string PaymentIntentId)
        {
            var Specs= new OrderPaymentSpecification(PaymentIntentId);
            var Order = await _unitOfWork.Repository<Orders, Guid>().GetWitSpecificationByIdAsync(Specs);
            if (Order == null)
                throw new Exception("Order Not Esist");
            Order.OrderStates=OrderStates.Canceld;
            _unitOfWork.Repository<Orders,Guid>().Update(Order);
            await _unitOfWork.CompleteAsync();
            var MappedOrder=_mapper.Map<OrderDetails>(Order);
            return MappedOrder;
        }
    }
}
