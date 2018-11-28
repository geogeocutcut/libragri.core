using System.Threading.Tasks;
using libragri.core.common;
using libragri.core.repository;

namespace libragri.core.repository.inmemorydb
{
    public abstract class AbstractUnitOfWorkInMemory<TId> : IUnitOfWork<TId>
    {
        private IStore<TId> _store;

        public AbstractUnitOfWorkInMemory(IStore<TId> store)
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
            return this._store;
        }

        public abstract Task<TRepository> GetRepository<TRepository>() where TRepository : IRepository<TId, Entity<TId>>;
    }
}