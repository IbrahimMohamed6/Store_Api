using StackExchange.Redis;
using Store.Data.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specifications.OrderSpecification
{
    public class OrderPaymentSpecification : BaseSpecification<Orders>
    {
        public OrderPaymentSpecification(string? PaymentIntentId) 
        : base(O=>O.PayMentIntentId==PaymentIntentId)
        {
        }
    }
}
