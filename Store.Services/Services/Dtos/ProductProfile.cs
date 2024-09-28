using AutoMapper;
using Store.Data.Entities;
using Store.Data.Entities.Brands;
using Store.Data.Entities.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.Dtos
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductDetailsDto>()
                .ForMember(dest=>dest.BrandName,opt=>opt.MapFrom(src=>src.Brand.Name))
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.Name))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<ProductPictureUrlResolver>());

            CreateMap<ProductBrands, BrandTypeDetailsDto>();
            CreateMap<ProductType, BrandTypeDetailsDto>();
                
        }
    }
}
