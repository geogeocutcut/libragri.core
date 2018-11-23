using System;
using System.Threading.Tasks;

namespace libragri.core.repository
{
    public interface IUnitOfWork<TId>:IDisposable
    {
        IStore<TId> GetStore(); 
        Task BeginAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}