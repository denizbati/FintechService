using FintechService.Domain;
using FintechService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace FintechService.Repository
{

    internal abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext _dbContext;

        protected readonly DbSet<TEntity> _entities;

        protected GenericRepository(DbContext context)
        {
            _entities = context.Set<TEntity>();
            _dbContext = context;

        }
        public async Task SaveAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }

        public TEntity Update(TEntity entity)
        {
            var entityEntry = _entities.Update(entity);
            return entityEntry.Entity;
        }

        public void Delete(TEntity entity)
        {
            entity.SetIsActive(false);
        }

        public async Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _entities.SingleOrDefaultAsync(predicate, cancellationToken);
        }
    }
}