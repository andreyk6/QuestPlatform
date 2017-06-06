using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using QuestPlatform.Domain.Infrastructure.Contracts;
using Store.Models;

namespace QuestPlatform.Domain.Infrastructure.Specifications.Concrette.UserInGames
{
    public class UserWithApplicationUserId : ISpecification<UserInGame>
    {
        private string applicationUserId;

        public UserWithApplicationUserId(string applicationUserId)
        {
            this.applicationUserId = applicationUserId;
        }

        public Expression<Func<UserInGame, bool>> IsSatisifiedBy()
        {
            return u => u.ApplicationUserId.Equals(applicationUserId);
        }
    }
}
