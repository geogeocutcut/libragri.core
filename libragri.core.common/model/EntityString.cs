using System;

namespace libragri.core.common
{
    public abstract class EntityString:Entity<string>
    {
        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(_id))
                    _id = Guid.NewGuid().ToString();
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public override string GetId()
        {
            return Id;
        }

    }
}
