using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Models;

namespace QuestPlatform.Domain.Infrastructure.Repositories
{
    public class UserInGameRepository : Repository<UserInGame>
    {
        public override void Update(UserInGame entity)
        {
            Set.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
