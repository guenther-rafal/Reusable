using System;
using System.Linq.Expressions;

namespace SmartFillCommon.Specification.Builder.Impl
{
    public class SpecificationBuilderExtender<TSpecificationSubject>
        : SpecificationBuilder<TSpecificationSubject>, ISpecificationBuilderExtender<TSpecificationSubject>
    {
        private ICompositeSpecificationBuilder<TSpecificationSubject> _compositeSpecificationBuilder
            => new CompositeSpecificationBuilder<TSpecificationSubject>(SpecificationExpression);

        public new ISpecificationBuilderExtender<TSpecificationSubject> Set(Expression<Func<TSpecificationSubject, bool>> expression)
        {
            SpecificationExpression = expression;
            return this;
        }

        public ICompositeSpecificationBuilder<TSpecificationSubject> Combine()
        {
            return _compositeSpecificationBuilder;
        }
    }
}
