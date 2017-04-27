using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestPlatform.Domain.Infrastructure.Contracts
{
    public interface IRepository<T>
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> Query(ISpecification<T> condition);
        Task<Guid> Insert(T entity);
        Task Delete(Guid id);
        Task Update(T entity);
        Task Save();
    }
}
