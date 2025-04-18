using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal abstract class BaseSpecifications<T> : ISpecifications<T> where T : class
    {
        protected BaseSpecifications(Expression<Func<T, bool>>? criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; private set; }

        public List<Expression<Func<T, object>>> IncludeExpressions { get; } = [];


        protected void AddInclude(Expression<Func<T, object>> include)
            => IncludeExpressions.Add(item: include);

        public List<Func<T, object>> OrderBy { get; } = new List<Func<T, object>>();
        public List<Func<T, object>> OrderByDescending { get; } = new List<Func<T, object>>();

        public void AddOrderBy(Func<T, object> orderBy)
        {
            OrderBy.Add(orderBy);
        }

        public void AddOrderByDescending(Func<T, object> orderByDescending)
        {
            OrderByDescending.Add(orderByDescending);
        }
    }
}
