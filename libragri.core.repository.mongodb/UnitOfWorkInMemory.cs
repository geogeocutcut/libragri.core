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
        public void CommitTransaction()
        {
        }

        public void Dispose()
        {
        }

        public void OpenTransaction()
        {
        }

        public void RollbackTransaction()
        {
        }
    }
}