using System;
using System.Linq.Expressions;

namespace Reusable.Specification.Builder
{
    public interface ISpecificationBuilder<TSubject>
    {
        IQuerySpecification<TSubject> BuildQuerySpecification();
        void Clear();
        ISpecificationBuilderExtender<TSubject> Set(Expression<Func<TSubject, bool>> expression);
    }
}