using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Entities.DelivtyMethods;
using Store.Services.HandleResponse;
using Store.Services.Services.OrderServices;
using Store.Services.Services.OrderServices.Dto;
using System.Security.Claims;

namespace Store.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<ActionResult<OrderDetails>> CreateOrderAsync(OrderDto input)
        {
            var Order = await _orderService.CreateOrderAsync(input);
            if (Order == null)
                return BadRequest(new Response(400, "Error While Creating Your Order"));
            return Ok(Order);
        }
        [HttpGet]
        public async Task<ActionResult<OrderDetails>> GetOrderByIdAsync(Guid id)
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var Orders = await _orderService.GetOrdertByidAsync(id);
            return Ok(Orders);

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderDetails>>> GetAllOrdersForUserAsync()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var Orders = await _orderService.GetAllOrderForUserAsync(Email);
            return Ok(Orders);

        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethods>>> GetAllDelivoryMethodByIdAsync()
        =>Ok(await _orderService.GetallDelivryMethodAsync());



    }
}
