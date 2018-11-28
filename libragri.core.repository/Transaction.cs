using System;
using System.Collections.Generic;
using System.Text;

namespace libragri.core.repository
{
    public class Transaction<TId>:ITransaction
    {
        private IUnitOfWork<TId> _uow;
        public Transaction(IUnitOfWork<TId> uow)
        {
            _uow = uow;
        }

        public void Commit()
        {
            _uow.CommitAsync();
        }


        public void Rollback()
        {
            _uow.RollbackAsync();
        }


        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
