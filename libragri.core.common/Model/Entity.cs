using System;

namespace libragri.core.common
{
    public abstract class Entity<TId>
    {
        private TId _id;

        public abstract TId GetId();
        public abstract void SetId(TId id);

    }
}
