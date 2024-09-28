using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Specifications.ProductPecs;
using Store.Services.Services.Dtos;
using Store.Services.Services.ProductServices;

namespace Store.Web.Controllers
{
    
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> GetAllProducts([FromQuery]ProductSpecification input)
            =>Ok(await _service.GetAllProductAsync(input));
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDetailsDto>>> GetAllBrands()
            => Ok(await _service.GetAllBrandsAsync());
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDetailsDto>>> GetAllTypes()
            => Ok(await _service.GetAllTyoesAsync());
        [HttpGet]
        public async Task<ActionResult<ProductDetailsDto>> GetAllProductById(int? id)
            => Ok(await _service.GetProductByidAsync(id));
    }
}
