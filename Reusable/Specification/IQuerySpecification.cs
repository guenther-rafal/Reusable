using System.Linq;

namespace Reusable.Specification
{
    public interface IQuerySpecification<TSubject> : ISpecification<IQueryable<TSubject>, IQueryable<TSubject>>
    {
    }
}
