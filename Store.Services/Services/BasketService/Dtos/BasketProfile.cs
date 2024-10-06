using AutoMapper;
using Store.Repository.BasketRepository.Models;

namespace Store.Services.Services.BasketService.Dtos
{
    public class BasketProfile:Profile
    {
        public BasketProfile()
        {
            CreateMap<CustomerBasket, CustomerBasketDto>().ReverseMap(); 
            CreateMap<BasketItem, BasketItemDto>().ReverseMap(); 
        }
    }
}
