using System;

namespace libragri.core.common
{
    public abstract class Entity<TId>
    {
        protected TId _id;

        public abstract TId GetId();

    }
}
