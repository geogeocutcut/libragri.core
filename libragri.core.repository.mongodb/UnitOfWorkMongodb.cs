using System.Threading.Tasks;
using libragri.core.common;
using libragri.core.repository;

namespace libragri.core.repository.mongodb
{
    public abstract class AbstractUnitOfWorkMongodb<TId> : IUnitOfWork<TId>
    {
        private IStore<TId> _store;
        private IFactory _factory;

        public AbstractUnitOfWorkMongodb(IFactory factory)
        {
            this._factory = factory;
            this._store = factory.Resolve<IStore<TId>>();
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