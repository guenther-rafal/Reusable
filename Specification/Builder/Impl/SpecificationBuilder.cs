using SmartFillCommon.Specification.Impl;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartFillCommon.Specification.Builder.Impl
{
    public class SpecificationBuilder<TSpecificationSubject> : ISpecificationBuilder<TSpecificationSubject>
    {
        protected internal Expression<Func<TSpecificationSubject, bool>> SpecificationExpression;

        public virtual ISpecificationBuilderExtender<TSpecificationSubject> Set(Expression<Func<TSpecificationSubject, bool>> expression)
        {
            SpecificationExpression = expression;
            var extender = new SpecificationBuilderExtender<TSpecificationSubject>();
            return extender.Set(expression);
        }

        public ISpecification<IQueryable<TSpecificationSubject>, IQueryable<TSpecificationSubject>> BuildQuerySpecification()
        {
            if (SpecificationExpression == null)
            {
                return new QuerySpecification<TSpecificationSubject>(z => true);
            }
            var result = new QuerySpecification<TSpecificationSubject>(SpecificationExpression);
            return result;
        }

        public void Clear()
        {
            SpecificationExpression = null;
        }
    }
}
