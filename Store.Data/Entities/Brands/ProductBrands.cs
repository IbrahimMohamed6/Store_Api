using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities.Brands
{
    public class ProductBrands:BaseEntity<int>
    {
        public string Name { get; set; } = null!;
    }
}
