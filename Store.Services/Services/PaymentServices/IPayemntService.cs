using Store.Services.Services.BasketService.Dtos;
using Store.Services.Services.OrderServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.PaymentServices
{
   public interface IPayemntService
    {

        Task<CustomerBasketDto>CreateOrUpdatePaymentIntent(CustomerBasketDto Input);
        Task<OrderDetails> UpdateOrderPaymentIntentSucced(string PaymentIntentId);
        Task<OrderDetails> UpdateOrderPaymentIntentFaild(string PaymentIntentId);

    }
}
