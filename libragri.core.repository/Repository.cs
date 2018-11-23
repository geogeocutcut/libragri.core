using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using libragri.core.common;

namespace libragri.core.repository
{
    public class Repository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : Entity<TId>
    {
        IStore<TId> store;

        public Repository(IUnitOfWork<TId> uow)
        {
            this.store=uow.GetStore();
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