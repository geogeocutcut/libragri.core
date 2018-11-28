using libragri.core.common;
using System;
using System.Threading.Tasks;

namespace libragri.core.repository
{
    public interface IUnitOfWork<TId>:IDisposable
    {
        IStore<TId> GetStore(); 
        Task<ITransaction> BeginAsync();
        Task CommitAsync();
        Task RollbackAsync();


        Task<TRepository> GetRepository<TRepository>() where TRepository : IRepository<TId, Entity<TId>>;
    }
}