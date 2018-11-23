namespace libragri.core.specification
{
    public class NotSpecification<T> : CompositeSpecification<T>    
    {
        ISpecification<T> spec;

        public NotSpecification(ISpecification<T> spec)  {
            this.spec = spec;
        }

        public override bool IsSatisfiedBy(T o)   {
            return !this.spec.IsSatisfiedBy(o);
        }
    }
}