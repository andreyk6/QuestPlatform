using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuestPlatform.Domain.Infrastructure.Contracts
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> IsSatisifiedBy();
    }
}
