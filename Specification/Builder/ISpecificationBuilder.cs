using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartFillCommon.Specification.Builder
{
    public interface ISpecificationBuilder<TSpecificationSubject>
    {
        ISpecification<IQueryable<TSpecificationSubject>, IQueryable<TSpecificationSubject>> BuildQuerySpecification();
        void Clear();
        ISpecificationBuilderExtender<TSpecificationSubject> Set(Expression<Func<TSpecificationSubject, bool>> expression);
    }
}