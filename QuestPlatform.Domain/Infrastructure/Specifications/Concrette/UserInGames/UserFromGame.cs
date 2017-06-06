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
    public class UserFromGame : ISpecification<UserInGame>
    {
        private Guid gameId;

        public UserFromGame(Guid gameId)
        {
            this.gameId = gameId;
        }

        public Expression<Func<UserInGame, bool>> IsSatisifiedBy()
        {
            return u => u.GameId.Equals(gameId);
        }
    }
}
