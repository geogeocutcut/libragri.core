

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using libragri.core.common;
using libragri.core.repository;

namespace libragri.core.repository.inmemorydb
{
    public class RepositoryInMemory<TId, TEntity> : IRepository<TId, TEntity> where TEntity : Entity<TId>
    {
        IStore<TId> store;

        public RepositoryInMemory(UnitOfWorkInMemory<TId> uow)
        {
            this.store=uow.Store;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await store.RemoveAsync<TEntity>(entity);
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await store.GetAllAsync<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await store.GetByIdAsync<TEntity>(id);
        }

        
        public async Task<IList<TEntity>> FindAsync(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> predicate)
        {
            return await store.FindAsync<TEntity>(predicate);
        }

        public async Task<TEntity> UpsertAsync(TEntity entity)
        {
            await store.UpsertAsync<TEntity>(entity);
            return entity;
        }
        
    }
}
