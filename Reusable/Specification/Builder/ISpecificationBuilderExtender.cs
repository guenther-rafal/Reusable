using System;
using System.Linq.Expressions;

namespace Reusable.Specification.Builder
{
    public interface ISpecificationBuilderExtender<TSubject> : ISpecificationBuilder<TSubject>
    {
        ICompositeSpecificationBuilder<TSubject> Combine();
        ISpecificationBuilderExtender<TSubject> Set(Expression<Func<TSubject, bool>> expression);
    }
}