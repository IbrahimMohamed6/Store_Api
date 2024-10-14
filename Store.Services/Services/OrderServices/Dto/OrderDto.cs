using System.ComponentModel.DataAnnotations;

namespace Store.Services.Services.OrderServices.Dto
{
    public class OrderDto
    {
        public string BaketId { get; set; }
        public string BuirEmail { get; set; }
        [Required]
        public int DeliveryMethod { get; set; }
        public AddressDto ShippingAddress { get; set; }

    }
}
