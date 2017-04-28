using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPlatform.Domain.Context;
using QuestPlatform.Domain.Infrastructure.Contracts;

namespace QuestPlatform.Domain.Infrastructure.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T: class
    {
        protected DataDbContext Context { get; set; }
        protected internal DbSet<T> Set { get; set; }

        protected AbstractRepository()
        {
            Context = new DataDbContext();
            Set = Context.Set<T>();
        }

        protected AbstractRepository(DataDbContext context)
        {
            Context = context;
        }

        public abstract Task<T> GetById(Guid id);
        public abstract Task<IEnumerable<T>> Get();
        public abstract IQueryable<T> Query(ISpecification<T> condition);
        public abstract void Insert(T entity);
        public abstract Task Delete(Guid id);
        public abstract void Update(T entity);
        public abstract Task Save();
    }
}
