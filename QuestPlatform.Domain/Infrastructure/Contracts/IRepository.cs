﻿using System;
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
        Task<T> Insert(T entity);
        Task<IEnumerable<T>> InsertRange(IEnumerable<T> range);
        Task Delete(Guid id);
        void Update(T entity);
        Task Save();
    }
}
