using System;
using System.Collections.Generic;
using System.Text;

namespace libragri.core.repository
{
    public interface ITransaction
    {
        void Commit();
        void Rollback();
    }
}
