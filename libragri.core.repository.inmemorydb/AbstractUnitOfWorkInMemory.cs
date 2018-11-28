using System.Threading.Tasks;
using libragri.core.common;
using libragri.core.repository;

namespace libragri.core.repository.inmemorydb
{
    public abstract class AbstractUnitOfWorkInMemory<TId> : IUnitOfWork<TId>
    {
        protected IStore<TId> _store;
        protected IFactory _factory;
        protected ITransaction _transaction;

        public AbstractUnitOfWorkInMemory(IFactory factory)
        {
            this._factory = factory;
            this._store = factory.Resolve<IStore<TId>>();
        }

        public async Task CommitAsync()
        {
            _transaction = null;
        }


        public async Task<ITransaction> BeginAsync()
        {
            if (_transaction != null)
            {
                return _transaction;
            }
            else
            {
                _transaction = new Transaction<TId>(this);
                return _transaction;
            }
        }

        public async Task RollbackAsync()
        {
            _transaction = null;
        }

        
        public void Dispose()
        {
            if(_transaction!=null)
            {
                RollbackAsync().Wait();
            }
        }

        public IStore<TId> GetStore()
        {
            return this._store;
        }

        public abstract Task<TRepository> GetRepository<TRepository>() where TRepository : IRepository<TId, Entity<TId>>;
    }
}