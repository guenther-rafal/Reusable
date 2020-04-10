using System;
using System.Linq;
using System.Linq.Expressions;

namespace Reusable.Specification.Impl
{
    public class QuerySpecification<TSpecificationSubject> : ISpecification<IQueryable<TSpecificationSubject>, IQueryable<TSpecificationSubject>>
    {
        private readonly Expression<Func<TSpecificationSubject, bool>> _expression;

        public QuerySpecification(Expression<Func<TSpecificationSubject, bool>> expression)
        {
            _expression = expression ?? throw new ArgumentNullException("Specification expression has to be set!");
        }

        public IQueryable<TSpecificationSubject> IsSatisfied(IQueryable<TSpecificationSubject> subject)
        {
            return subject.Where(_expression);
        }
    }
}
