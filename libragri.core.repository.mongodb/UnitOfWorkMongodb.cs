using System.Threading.Tasks;
using libragri.core.common;
using libragri.core.repository;

namespace libragri.core.repository.mongodb
{
    public abstract class AbstractUnitOfWorkMongodb<TId> : IUnitOfWork<TId>
    {
        public IStore<TId> _store { get; set; }
        public AbstractUnitOfWorkMongodb(IStore<TId> store )
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

        public abstract Task<TRepository> GetRepository<TRepository>() where TRepository : IRepository<TId, Entity<TId>>;
    }
}