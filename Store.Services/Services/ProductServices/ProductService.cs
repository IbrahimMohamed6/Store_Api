using AutoMapper;
using Store.Data.Entities;
using Store.Data.Entities.Brands;
using Store.Data.Entities.Type;
using Store.Repository.Interfaces;
using Store.Repository.Specifications.ProductPecs;
using Store.Services.Helper;
using Store.Services.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands=await _unitOfWork.Repository<ProductBrands,int>().GetAllAsync();
            var MabbedBrands=_mapper.Map< IReadOnlyList<BrandTypeDetailsDto>>(brands);
            return MabbedBrands;
        }

        public async Task<PaginatedResultDto<ProductDetailsDto>> GetAllProductAsync(ProductSpecification input)
        {
            var Spec= new ProductWithSpecifications(input);
            
            
            var Products= await _unitOfWork.Repository<Product,int>().GetWitSpecificationAllAsync(Spec);
           var Countpecs=new ProductWitCountSprcification(input);
            var Count = await _unitOfWork.Repository<Product, int>().GetCountSpecificationAsy(Countpecs);
            var MappedProduct = _mapper.Map< IReadOnlyList < ProductDetailsDto >>(Products);
            return new PaginatedResultDto<ProductDetailsDto>(input.PAgeDefult,input.PageSize, Count, MappedProduct);
           
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTyoesAsync()
        {
            var Types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();
            var MabbedTypes= _mapper.Map< IReadOnlyList < BrandTypeDetailsDto >>(Types);
            return MabbedTypes;

        }

        public async Task<ProductDetailsDto> GetProductByidAsync(int? id)
        {
            if(id is null) 
                throw new ArgumentNullException("Id Is Null");
            var Specs = new ProductWithSpecifications(id);

            var Product= await _unitOfWork.Repository<Product,int>().GetWitSpecificationByIdAsync(Specs);
           if(Product is null)
                throw new ArgumentNullException("Product Not Found");

            var MappedProduct = _mapper.Map< ProductDetailsDto > (Product);
            return MappedProduct;
        }
    }
}
