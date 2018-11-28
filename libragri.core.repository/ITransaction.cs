using System;
using System.Collections.Generic;
using System.Text;

namespace libragri.core.repository
{
    public interface ITransaction:IDisposable
    {
        void Commit();
        void Rollback();
    }
}
