using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.BasketRepository.Models
{
    public class CustomerBasket
    {
        public string? Id { get; set; }
        public int? DelivryMethodId { get; set; }

        public decimal ShipingPrice { get; set; }

        public List<BasketItem> BasketItems { get; set; }=new List<BasketItem> { };
        public string? PayMentIntentId { get; set; }
        public string? ClientSecret { get; set; }

    }
}
