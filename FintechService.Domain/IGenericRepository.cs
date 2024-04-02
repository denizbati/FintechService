using FintechService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FintechService.Domain
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
     
        Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> predicate, System.Threading.CancellationToken cancellationToken);
        Task SaveAsync(TEntity entity);
        //to do update has to be async
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}