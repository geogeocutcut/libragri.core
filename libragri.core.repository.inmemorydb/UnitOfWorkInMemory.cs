using System.Threading.Tasks;
using libragri.core.common;
using libragri.core.repository;

namespace libragri.core.repository.inmemorydb
{
    public class UnitOfWorkInMemory<TId> : IUnitOfWork<TId>
    {
        public IStore<TId> Store { get; set; }
        public UnitOfWorkInMemory(IStore<TId> Store )
        {
            this.Store=Store;
        }
        public async Task CommitAsync()
        {
        }


        public async Task BeginAsync()
        {
        }

        public async Task RollbackAsync()
        {
        }

        
        public void Dispose()
        {
        }
    }
}