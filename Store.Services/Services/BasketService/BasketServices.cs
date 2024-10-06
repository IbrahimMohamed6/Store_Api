

using AutoMapper;
using Store.Repository.BasketRepository;
using Store.Repository.BasketRepository.Models;
using Store.Services.Services.BasketService.Dtos;

namespace Store.Services.Services.BasketService
{
    public class BasketServices : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketServices(IBasketRepository  basketRepository,
            IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        public async Task<bool> DeleteBAsketAsy(string BasketId)
        => await _basketRepository.DeleteBAsketAsy(BasketId);

        public async Task<CustomerBasketDto> GetBasketAsy(string BasketId)
        {
            var basket = await _basketRepository.GetBasketAsy(BasketId);
            if(basket == null)
                return new CustomerBasketDto();
            var MAppedBasket=_mapper.Map<CustomerBasketDto>(basket);
            return MAppedBasket;
        }

        public async Task<CustomerBasketDto> UpdateBasketAsy(CustomerBasketDto BAsket)
        {
            if (BAsket.Id is null)
               BAsket.Id=GenerateRundombasketId();
                var CustomrtBasket=_mapper.Map<CustomerBasket>(BAsket);
            var Updated=await _basketRepository.UpdateBasketAsy(CustomrtBasket);

            var UpdatedBasket=_mapper.Map<CustomerBasketDto>(Updated);
            return UpdatedBasket;

        }

        private string GenerateRundombasketId()
        {
            Random rnd = new Random();
            int RundomDigit = rnd.Next(1000, 10000);
            return $"Bs-{RundomDigit}";
        }
    }
}
