using SmartFillCommon.Extension;
using System;
using System.Linq.Expressions;

namespace SmartFillCommon.Specification.Builder.Impl
{
    public class CompositeSpecificationBuilder<TSpecificationSubject>
        : SpecificationBuilderExtender<TSpecificationSubject>, ICompositeSpecificationBuilder<TSpecificationSubject>
    {
        public CompositeSpecificationBuilder(Expression<Func<TSpecificationSubject, bool>> expression)
        {
            SpecificationExpression = expression;
        }

        public ICompositeSpecificationBuilder<TSpecificationSubject> And(Expression<Func<TSpecificationSubject, bool>> expression)
        {
            SpecificationExpression = SpecificationExpression.And(expression);
            return this;
        }

        public ICompositeSpecificationBuilder<TSpecificationSubject> Or(Expression<Func<TSpecificationSubject, bool>> expression)
        {
            SpecificationExpression = SpecificationExpression.Or(expression);
            return this;
        }

        public ICompositeSpecificationBuilder<TSpecificationSubject> AndIf(Expression<Func<TSpecificationSubject, bool>> expression, bool condition)
        {
            if (condition)
            {
                SpecificationExpression = SpecificationExpression.And(expression);
            }
            return this;
        }

        public ICompositeSpecificationBuilder<TSpecificationSubject> OrIf(Expression<Func<TSpecificationSubject, bool>> expression, bool condition)
        {
            if (condition)
            {
                SpecificationExpression = SpecificationExpression.Or(expression);
            }
            return this;
        }
    }
}
