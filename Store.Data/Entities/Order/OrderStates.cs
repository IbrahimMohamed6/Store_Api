using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities.Order
{
    public enum OrderStates
    {
        Placed,
        Running,
        Delevring,
        Dliverd,
        Canceld
    }
}
