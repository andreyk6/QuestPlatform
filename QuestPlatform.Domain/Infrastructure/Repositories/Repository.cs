using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPlatform.Domain.Infrastructure.Contracts;
using Store.Models;

namespace QuestPlatform.Domain.Infrastructure.Repositories
{
    public class Repository<T> : AbstractRepository<T> where T: class
    {
        public override async Task<T> GetById(Guid id)
        {
            return await Set.FindAsync(id);
        }

        public override async Task<IEnumerable<T>> Get()
        {
            return await Set.ToListAsync();
        }

        public override IQueryable<T> Query(ISpecification<T> condition)
        {
            return Set.Where(condition.IsSatisifiedBy());
        }

        public override void Insert(T entity)
        {
            Set.Add(entity);
        }

        public override async Task Delete(Guid id)
        {
            var deletedItem = await Set.FindAsync(id);
            Delete(deletedItem);
        }

        private void Delete(T entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                Set.Attach(entityToDelete);
            }
            Set.Remove(entityToDelete);
        }

        public override void Update(T entity)
        {
            Set.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public override async Task Save()
        {
            await Context.SaveChangesAsync();
        }
    }
}
