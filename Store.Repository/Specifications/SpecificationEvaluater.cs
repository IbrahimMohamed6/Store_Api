

using Microsoft.EntityFrameworkCore;
using Store.Data.Entities;

namespace Store.Repository.Specifications
{
    public class SpecificationEvaluater<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQuery, ISpecifications<TEntity> Spec)
        {
            var Query = InputQuery;
            if (Spec.Ceriteria is not null)
                Query = Query.Where(Spec.Ceriteria);

            if (Spec.OrderBy is not null)
                Query = Query.OrderBy(Spec.OrderBy);
            if (Spec.OrderByDescinding is not null)
                Query = Query.OrderByDescending(Spec.OrderByDescinding);

            if (Spec.Ispaginated)
                Query = Query.Skip(Spec.Skip).Take(Spec.Take);
            Query = Spec.Includes.Aggregate(Query, (Current, includeexpression) => Current.Include(includeexpression));
            return Query;
        }
    }
}
