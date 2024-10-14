using Store.Data.Entities.DelivtyMethods;
using Store.Services.Services.Dtos;
using Store.Services.Services.OrderServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.OrderServices
{
    public interface IOrderService
    {
        Task<OrderDetails> CreateOrderAsync(OrderDto Input);

        Task<IReadOnlyList<OrderDetails>> GetAllOrderForUserAsync(string buyreEmail);
        Task<OrderDetails> GetOrdertByidAsync(Guid Id);
        Task<DeliveryMethods> GetallDelivryMethodAsync();
    }
}
