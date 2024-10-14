using AutoMapper;
using StackExchange.Redis;
using Store.Data.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.OrderServices.Dto
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<ShippingAddress, AddressDto>().ReverseMap();
            CreateMap<Orders, OrderDetails>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>()
                 .ForMember(dest => dest.ProductItemId, opt => opt.MapFrom(src => src.ProductItem.ProductId))
                 .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductItem.ProductName))
                 .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<OrderItemPictureUrlResolver>()).ReverseMap();


        }
    }
}
