using Reusable.Specification.Impl;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Reusable.Specification.Builder.Impl
{
    public class SpecificationBuilder<TSubject> : ISpecificationBuilder<TSubject>
    {
        protected internal Expression<Func<TSubject, bool>> Expression;

        public virtual ISpecificationBuilderExtender<TSubject> Set(Expression<Func<TSubject, bool>> expression)
        {
            Expression = expression;
            var extender = new SpecificationBuilderExtender<TSubject>();
            return extender.Set(expression);
        }

        public IQuerySpecification<TSubject> BuildQuerySpecification()
        {
            if (Expression == null)
            {
                return new QuerySpecification<TSubject>(z => true);
            }
            var result = new QuerySpecification<TSubject>(Expression);
            return result;
        }

        public void Clear()
        {
            Expression = null;
        }
    }
}
