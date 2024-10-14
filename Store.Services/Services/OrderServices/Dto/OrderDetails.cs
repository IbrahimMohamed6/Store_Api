using Store.Data.Entities.DelivtyMethods;
using Store.Data.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.OrderServices.Dto
{
    public class OrderDetails
    {
        public Guid Id { get; set; }
        public string BuierEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public DeliveryMethods DeliveryMethods { get; set; }
        public int? DeliveryMethodsId { get; set; }
        public OrderStates OrderStates { get; set; } 
        public OrderPayment OrderPayment { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GetTotal
            => SubTotal + DeliveryMethods.Price;
        public string? BasketId { get; set; }
        public string? PayMentIntentId { get; set; }
        
    }
}
