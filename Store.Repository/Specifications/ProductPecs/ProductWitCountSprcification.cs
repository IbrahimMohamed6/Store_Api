using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specifications.ProductPecs
{
    public class ProductWitCountSprcification : BaseSpecification<Product>
    {
        public ProductWitCountSprcification(ProductSpecification Spec)
           : base(Product => (!Spec.BrandId.HasValue || Product.BrandId == Spec.BrandId.Value) &&
                (!Spec.TypeId.HasValue || Product.TypeId == Spec.TypeId.Value)&&
                       (string.IsNullOrEmpty(Spec.Search) || Product.Name.Trim().ToLower().Contains(Spec.Search))

           )
        {

        }
    }
}
