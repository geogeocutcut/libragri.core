
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using libragri.core.common;

namespace libragri.core.repository
{
    public interface IStore<TId>
    {
        Task<TEntity> GetByIdAsync<TEntity>(TId id) where TEntity : Entity<TId>;
        Task<TEntity> UpsertAsync<TEntity>(TEntity entity) where TEntity : Entity<TId>;
        Task RemoveAsync<TEntity>(TEntity entity) where TEntity : Entity<TId>;
        Task<IList<TEntity>> GetAllAsync<TEntity>() where TEntity : Entity<TId>;
        Task<IList<TEntity>> FindAsync<TEntity>(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> predicate) where TEntity : Entity<TId>;

    }
}
