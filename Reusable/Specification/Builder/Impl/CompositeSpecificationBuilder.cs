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
            var andExpression = System.Linq.Expressions.Expression.And(Expression, expression) as Expression<Func<TSubject, bool>>;
            SetSpecificationExpression(andExpression);
            return this;
        }

        private void SetSpecificationExpression(Expression<Func<TSubject, bool>> newExpression)
        {
            Expression = System.Linq.Expressions.Expression.Lambda<Func<TSubject, bool>>(newExpression);
        }

        public ICompositeSpecificationBuilder<TSubject> Or(Expression<Func<TSubject, bool>> expression)
        {
            var orExpression = System.Linq.Expressions.Expression.Or(Expression, expression) as Expression<Func<TSubject, bool>>;
            SetSpecificationExpression(orExpression);
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
