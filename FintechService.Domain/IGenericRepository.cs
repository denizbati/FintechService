using FintechService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FintechService.Domain
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(Guid id, bool isActive = true);
        Task<List<TEntity>> AllAsync(bool isActive = true);
        Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> predicate, System.Threading.CancellationToken cancellationToken);
        Task<List<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> predicate, bool isActive = true);
        Task SaveAsync(TEntity entity);
        //to do update has to be async
        TEntity Update(TEntity entity);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, bool isActive = true);
        void Delete(TEntity entity);
    }
}