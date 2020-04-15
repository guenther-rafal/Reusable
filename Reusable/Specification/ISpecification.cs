namespace Reusable.Specification
{
    public interface ISpecification<TSubject, TReturn>
    {
        TReturn IsSatisfied(TSubject subject);
    }
}
