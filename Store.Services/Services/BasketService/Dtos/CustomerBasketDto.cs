using Store.Repository.BasketRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.BasketService.Dtos
{
    public class CustomerBasketDto
    {
        public string? Id { get; set; }
        public int? DelivryMethodId { get; set; }

        public decimal ShipingPrice { get; set; }

        public List<BasketItemDto> BasketItems { get; set; } = new List<BasketItemDto> { };

        public string? PayMentIntentId { get; set; }
        public string? ClientSecret { get; set; }
    }
}
