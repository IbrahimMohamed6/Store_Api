using Store.Services.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.ProductServices
{
    public interface IProductService
    {
        Task<IReadOnlyList<ProductDetailsDto>> GetAllProductAsync();
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync();
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTyoesAsync();
        Task<ProductDetailsDto> GetProductByidAsync(int?id);
        
        
    }
}
