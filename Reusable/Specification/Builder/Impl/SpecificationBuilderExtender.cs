using System;
using System.Linq.Expressions;

namespace Reusable.Specification.Builder.Impl
{
    public class SpecificationBuilderExtender<TSubject>
        : SpecificationBuilder<TSubject>, ISpecificationBuilderExtender<TSubject>
    {
        private ICompositeSpecificationBuilder<TSubject> _compositeSpecificationBuilder
            => new CompositeSpecificationBuilder<TSubject>(Expression);

        public new ISpecificationBuilderExtender<TSubject> Set(Expression<Func<TSubject, bool>> expression)
        {
            Expression = expression;
            return this;
        }

        public ICompositeSpecificationBuilder<TSubject> Combine()
        {
            return _compositeSpecificationBuilder;
        }
    }
}
