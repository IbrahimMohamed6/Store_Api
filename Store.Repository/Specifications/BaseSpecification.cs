using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Ceriteria = criteria;
        }
        public Expression<Func<T, bool>> Ceriteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescinding { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }


        public bool Ispaginated { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> IncludeExpression)
            => Includes.Add(IncludeExpression);
        protected void AddOrderBy(Expression<Func<T, object>> OrderByExpression)
            => OrderBy = OrderByExpression;
        protected void AddOrderByDescinding(Expression<Func<T, object>> OrderByExpressionDescinding)
           => OrderByDescinding = OrderByExpressionDescinding;


        protected void ApplayPagination(int skip, int take)
        {
            Take = take;
            Skip = skip;
            Ispaginated= true;
        }

    }
}
