using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZhrachkaBot.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        Task RemoveAsync(TEntity entity);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        TEntity GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);
    }
}
