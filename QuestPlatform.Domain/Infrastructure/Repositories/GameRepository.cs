using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Models;

namespace QuestPlatform.Domain.Infrastructure.Repositories
{
    public class GameRepository : Repository<Game>
    {
        public override async Task<Game> GetById(Guid id)
        {
            return await Context.Games.Where(q => q.Id.Equals(id))
                                            .Include("Users.Game")
                                            .FirstOrDefaultAsync();
        }
    }
}
