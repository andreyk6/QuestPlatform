using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPlatform.Domain.Context;

namespace QuestPlatform.Domain.Infrastructure.Repositories
{
    internal abstract class AbstractRepository
    {
        protected DataDbContext Context { get; set; }

        protected AbstractRepository()
        {
            Context = new DataDbContext();
        }

        protected AbstractRepository(DataDbContext context)
        {
            Context = context;
        }
    }
}
