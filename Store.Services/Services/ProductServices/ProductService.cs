using Store.Data.Entities;
using Store.Data.Entities.Brands;
using Store.Data.Entities.Type;
using Store.Repository.Interfaces;
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

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands=await _unitOfWork.Repository<ProductBrands,int>().GetAllAsync();
            var MabbedBrands = brands.Select(b => new BrandTypeDetailsDto
            {
                Id = b.Id,
                Name = b.Name,
                CreatedAt= b.CreatedAt,
            }).ToList();
            return MabbedBrands;
        }

        public async Task<IReadOnlyList<ProductDetailsDto>> GetAllProductAsync()
        {
            var Products= await _unitOfWork.Repository<Product,int>().GetAllAsync();
            var MappedProduct = Products.Select(b => new ProductDetailsDto
            {
                Id = b.Id,
                Name = b.Name,
                CreatedAt= b.CreatedAt,
                Description=b.Description,
                Price=b.Price,
                PictureUrl=b.PictureUrl,
                BrandName=b.Brand.Name,
                TypeName=b.Type.Name
                
            }).ToList();
            return MappedProduct;
           
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTyoesAsync()
        {
            var Types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();
            var MabbedTypes= Types.Select(b => new BrandTypeDetailsDto
            {
                Id = b.Id,
                Name = b.Name,
                CreatedAt = b.CreatedAt,
            }).ToList();
            return MabbedTypes;

        }

        public async Task<ProductDetailsDto> GetProductByidAsync(int? id)

        {
            if(id is null) 
                throw new ArgumentNullException("Id Is Null");

            var Product= await _unitOfWork.Repository<Product,int>().GetByIdAsync(id.Value);
           if(Product is null)
                throw new ArgumentNullException("Product Not Found");

            var MappedProduct = new ProductDetailsDto()
            {
                Id = Product.Id,
                Name = Product.Name,
                Description = Product.Description,
                Price = Product.Price,
                PictureUrl = Product.PictureUrl,
                BrandName = Product.Brand.Name,
                TypeName = Product.Type.Name

            };
            return MappedProduct;
        }
    }
}
