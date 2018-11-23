using System.Threading.Tasks;
using libragri.core.common;
using libragri.core.repository;

namespace libragri.core.repository.mongodb
{
    public class UnitOfWorkMongodb<TId> : IUnitOfWork<TId>
    {
        public IStore<TId> _store { get; set; }
        public UnitOfWorkMongodb(IStore<TId> store )
        {
            this._store=store;
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

        public IStore<TId> GetStore()
        {
            return _store;
        }
    }
}