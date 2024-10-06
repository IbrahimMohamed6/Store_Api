using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Services.BasketService;
using Store.Services.Services.BasketService.Dtos;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<CustomerBasketDto>> GetBasketAsync(string Id)
            =>Ok(await _basketService.GetBasketAsy(Id));

        [HttpPost("{Id}")]
        public async Task<ActionResult<CustomerBasketDto>> UpdateBasketAsync(CustomerBasketDto Input)
            => Ok(await _basketService.UpdateBasketAsy(Input));

        [HttpDelete("{Id}")]
        public async Task<ActionResult<bool>>DeleteBasketAsync(string Id)
            => Ok(await _basketService.DeleteBAsketAsy(Id));
    }
}
