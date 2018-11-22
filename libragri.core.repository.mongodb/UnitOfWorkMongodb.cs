using System.Threading.Tasks;
using libragri.core.common;
using libragri.core.repository;

namespace libragri.core.repository.mongodb
{
    public class UnitOfWorkMongodb<TId> : IUnitOfWork<TId>
    {
        public IStore<TId> Store { get; set; }
        public UnitOfWorkMongodb(IStore<TId> Store )
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