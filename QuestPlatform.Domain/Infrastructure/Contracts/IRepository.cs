using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestPlatform.Domain.Infrastructure.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> Get();
        IQueryable<T> Query(ISpecification<T> condition);
        void Insert(T entity);
        Task Delete(Guid id);
        void Update(T entity);
        Task Save();
    }
}
