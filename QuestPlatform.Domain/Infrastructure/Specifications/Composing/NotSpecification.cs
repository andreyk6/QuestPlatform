using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using QuestPlatform.Domain.Infrastructure.Contracts;

namespace QuestPlatform.Domain.Infrastructure.Specifications.Composing
{
    public class NotSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> specification;

        public NotSpecification(ISpecification<T> specification)
        {
            this.specification = specification;
        }

        public Expression<Func<T, bool>> IsSatisifiedBy()
        {
            var expression = specification.IsSatisifiedBy();

            var parameter = expression.Parameters[0];
            var body = Expression.Not(expression.Body);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
