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
    public class OrderSpecification : BaseSpecification<Orders>
    {
        public OrderSpecification(string buyreEmail) : base(Order=>Order.BuierEmail==buyreEmail)
        {
            AddInclude(o=>o.DeliveryMethods);
            AddInclude(o=>o.OrderItems);
            AddInclude(o=>o.OrderDate);
        }

        public OrderSpecification(Guid id) : base(Order => Order.Id == id)
        {
            AddInclude(o => o.DeliveryMethods);
            AddInclude(o => o.OrderItems);
           
        }
    }
}
