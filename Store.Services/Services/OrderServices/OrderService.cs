using AutoMapper;
using StackExchange.Redis;
using Store.Data.Entities;
using Store.Data.Entities.DelivtyMethods;
using Store.Data.Entities.Order;
using Store.Repository.Interfaces;
using Store.Repository.Specifications.OrderSpecification;
using Store.Services.Services.BasketService;
using Store.Services.Services.OrderServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IBasketService _basketService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IBasketService  basketService,
            IUnitOfWork unitOfWork,
            IMapper mapper

            )
        {
           _basketService = basketService;
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderDetails> CreateOrderAsync(OrderDto Input)
        {
            var basket=await _basketService.GetBasketAsy(Input.BaketId);
            if (basket == null)
                throw new Exception("Basket Not Exsist");
            var OrderItems=new List<OrderItemDto>();

            foreach(var item in basket.BasketItems)
            {
                var ProductItem=await _unitOfWork.Repository<Product,int>().GetByIdAsync(item.ProductId);
               if(ProductItem == null)
                    throw new Exception("Product Not Exsist");
                var ItemOrder = new ProductItem
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    PictureUrl = item.PictureUrl,
                };
                var OrderItem = new OrderItem
                {
                    Price = item.Price,
                    Quantity = item.Quantity,

                };
                var Mapped= _mapper.Map<OrderItemDto>(ItemOrder);
                OrderItems.Add(Mapped);
                
            }


            var DeliveryMethod= await _unitOfWork.Repository<DeliveryMethods, int>().GetByIdAsync(Input.DeliveryMethod);
            if (DeliveryMethod == null)
                throw new Exception("Delevry Not Add");
            var SubTotal=OrderItems.Sum(I=>I.Quantity*I.Price);
            var MappedShippingAddress=_mapper.Map<ShippingAddress>(Input.ShippingAddress);
            var MappedOrderItems = _mapper.Map<List<OrderItem>>(OrderItems);
            var Order = new Orders
            {
                DeliveryMethodsId = DeliveryMethod.Id,
                ShippingAddress = MappedShippingAddress,
                BuierEmail = Input.BuirEmail,
                BasketId = Input.BaketId,
                OrderItems = MappedOrderItems,
                SubTotal=SubTotal,
                

            };
            await _unitOfWork.Repository<Orders, Guid>().AddAsync(Order);
            await _unitOfWork.CompleteAsync();
            var MappedOrder=_mapper.Map<OrderDetails>(Order);
            return MappedOrder;
        }

        public Task<DeliveryMethods> GetallDelivryMethodAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<OrderDetails>> GetAllOrderForUserAsync(string buyreEmail)
        {
            var Specs = new OrderSpecification(buyreEmail);
            var orders = await _unitOfWork.Repository<Orders, Guid>().GetWitSpecificationAllAsync(Specs);
            if (!orders.Any())
                throw new Exception("Not Exist");
            var MappedOrder = _mapper.Map<List<OrderDetails>>(orders);
            return MappedOrder;


        }

        public async Task<OrderDetails> GetOrdertByidAsync(Guid Id)
        {
            var Specs = new OrderSpecification(Id);
            var order = await _unitOfWork.Repository<Orders, Guid>().GetWitSpecificationByIdAsync(Specs);
            if (order is null)
                throw new Exception("Not Exist");
            var MappedOrder = _mapper.Map<OrderDetails>(order);
            return MappedOrder;
        }
    }
}
