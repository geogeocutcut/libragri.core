
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using libragri.core.common;

namespace libragri.core.repository
{
    public interface IRepository<TId,TEntity> where TEntity : Entity<TId>
    {
        Task<TEntity> GetByIdAsync(TId Id);
        Task<TEntity> UpsertAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<IList<TEntity>> GetAllAsync();
        
        
        Task<IList<TEntity>> FindAsync(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> predicate);
    }
}
