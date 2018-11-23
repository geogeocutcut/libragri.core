using System;

namespace libragri.core.common
{
    public class AuditableEntity<TId>:Entity<TId>
    {
        public virtual DateTime CreatedDate {get;set;}
        public virtual string CreatedBy {get;set;}
        public virtual DateTime UpdatedDate {get;set;}
        public virtual string UpdatedBy {get;set;}
        public virtual DateTime DeletedDate {get;set;}
        public virtual string DeletedtedBy {get;set;}
    }
}