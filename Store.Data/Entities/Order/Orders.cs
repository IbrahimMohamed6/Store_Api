
namespace Store.Data.Entities.Order
{
    public class Orders : BaseEntity<Guid>
    {
        public string BuierEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public ShippingAddress ShippingAddress { get; set; }
        public DelivtyMethods.DeliveryMethods DeliveryMethods { get; set; }
        public int? DeliveryMethodsId { get; set; }
        public OrderStates OrderStates { get; set; } = OrderStates.Placed;
        public OrderPayment OrderPayment { get; set; } = OrderPayment.Pending;
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal SubTotal { get; set; }
        public decimal GetTotal
            => SubTotal + DeliveryMethods.Price;
        public string? BasketId { get; set; }


    }
}
