using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specifications.ProductPecs
{
    public class ProductWithSpecifications : BaseSpecification<Product>
    {
        public ProductWithSpecifications(ProductSpecification Spec)
            : base(Product => (!Spec.BrandId.HasValue || Product.BrandId == Spec.BrandId.Value) &&
                 (!Spec.TypeId.HasValue || Product.TypeId == Spec.TypeId.Value) &&
            (string.IsNullOrEmpty(Spec.Search) || Product.Name.Trim().ToLower().Contains(Spec.Search)))
        {
            AddInclude(X => X.Brand);
            AddInclude(X => X.Type);
            AddOrderBy(X => X.Name);
            ApplayPagination(Spec.PageSize*(Spec.PAgeDefult-1), Spec.PageSize);
            if (!string.IsNullOrEmpty(Spec.Sort))
            {
                switch (Spec.Sort)
                {
                    case "PriceAsc":
                        AddOrderBy(X => X.Price);
                        break;
                    case "PriceDesc":
                        AddOrderByDescinding(X => X.Price);
                        break;
                    default:
                        AddOrderBy(X => X.Name);
                        break;

                }
            }
        }
        public ProductWithSpecifications(int? id) : base(Product => Product.Id==id)
        {
            AddInclude(X => X.Brand);
            AddInclude(X => X.Type);
          
        }
    }
}
