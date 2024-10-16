using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Services.BasketService.Dtos;
using Store.Services.Services.PaymentServices;

namespace Store.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPayemntService _payemntService;

        public PaymentController(IPayemntService payemntService)
        {
            _payemntService = payemntService;
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>>CreateOrUpdatePaymentIntent(CustomerBasketDto input)
        =>Ok(await _payemntService.CreateOrUpdatePaymentIntent(input));
    }
}
