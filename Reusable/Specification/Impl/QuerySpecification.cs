using System;
using System.Linq;
using System.Linq.Expressions;

namespace Reusable.Specification.Impl
{
    public class QuerySpecification<TSubject> : IQuerySpecification<TSubject>
    {
        private readonly Expression<Func<TSubject, bool>> _expression;

        public QuerySpecification(Expression<Func<TSubject, bool>> expression)
        {
            _expression = expression ?? throw new ArgumentNullException("Specification expression has to be set!");
        }

        public IQueryable<TSubject> IsSatisfied(IQueryable<TSubject> subject)
        {
            return subject.Where(_expression);
        }
    }
}
