using Reusable.Specification.ExpressionExtension;
using System;
using System.Linq.Expressions;

namespace Reusable.Specification.Builder.Impl
{
    public class CompositeSpecificationBuilder<TSubject>
        : SpecificationBuilderExtender<TSubject>, ICompositeSpecificationBuilder<TSubject>
    {
        public CompositeSpecificationBuilder(Expression<Func<TSubject, bool>> expression)
        {
            Expression = expression;
        }

        public ICompositeSpecificationBuilder<TSubject> And(Expression<Func<TSubject, bool>> expression)
        {
            Expression = Expression.And(expression);
            return this;
        }

        public ICompositeSpecificationBuilder<TSubject> AndIf(Expression<Func<TSubject, bool>> expression, bool condition)
        {
            if (condition)
            {
                return And(expression);
            }
            return this;
        }

        public ICompositeSpecificationBuilder<TSubject> Or(Expression<Func<TSubject, bool>> expression)
        {
            Expression = Expression.Or(expression);
            return this;
        }

        public ICompositeSpecificationBuilder<TSubject> OrIf(Expression<Func<TSubject, bool>> expression, bool condition)
        {
            if (condition)
            {
                return Or(expression);
            }
            return this;
        }
    }
}
