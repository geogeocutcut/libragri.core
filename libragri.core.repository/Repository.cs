using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using libragri.core.common;

namespace libragri.core.repository
{
    public class Repository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : Entity<TId>
    {
        private IStore<TId> _store;

        public Repository(IStore<TId> store)
        {
            _store=store;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _store.RemoveAsync<TEntity>(entity);
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _store.GetAllAsync<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await _store.GetByIdAsync<TEntity>(id);
        }

        
        public async Task<IList<TEntity>> FindAsync(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> predicate)
        {
            return await _store.FindAsync<TEntity>(predicate);
        }

        public async Task<TEntity> UpsertAsync(TEntity entity)
        {
            await _store.UpsertAsync<TEntity>(entity);
            return entity;
        }
        
    }
}