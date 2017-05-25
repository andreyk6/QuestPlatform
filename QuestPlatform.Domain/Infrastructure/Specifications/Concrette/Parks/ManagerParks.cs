using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using QuestPlatform.Domain.Infrastructure.Contracts;
using Store.Models;

namespace QuestPlatform.Domain.Infrastructure.Specifications.Concrette.Parks
{
    public class ManagerParks : ISpecification<Park>
    {
        private readonly string ManagerId;

        public ManagerParks(string managerId)
        {
            ManagerId = managerId;
        }

        public Expression<Func<Park, bool>> IsSatisifiedBy()
        {
            return p => p.ManagerId.Equals(ManagerId);
        }
    }
}
