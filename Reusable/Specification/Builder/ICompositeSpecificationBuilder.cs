using System;
using System.Linq.Expressions;

namespace Reusable.Specification.Builder
{
    public interface ICompositeSpecificationBuilder<TSubject> : ISpecificationBuilderExtender<TSubject>
    {
        ICompositeSpecificationBuilder<TSubject> And(Expression<Func<TSubject, bool>> expression);
        ICompositeSpecificationBuilder<TSubject> Or(Expression<Func<TSubject, bool>> expression);
        ICompositeSpecificationBuilder<TSubject> AndIf(Expression<Func<TSubject, bool>> expression, bool condition);
        ICompositeSpecificationBuilder<TSubject> OrIf(Expression<Func<TSubject, bool>> expression, bool condition);
    }
}