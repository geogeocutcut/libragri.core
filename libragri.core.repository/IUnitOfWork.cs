using System;
using System.Threading.Tasks;

namespace libragri.core.repository
{
    public interface IUnitOfWork<TId>:IDisposable
    {
        Task BeginAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}