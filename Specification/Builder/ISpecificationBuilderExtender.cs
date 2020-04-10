using System;
using System.Linq.Expressions;

namespace SmartFillCommon.Specification.Builder
{
    public interface ISpecificationBuilderExtender<TSpecificationSubject> : ISpecificationBuilder<TSpecificationSubject>
    {
        ICompositeSpecificationBuilder<TSpecificationSubject> Combine();
        ISpecificationBuilderExtender<TSpecificationSubject> Set(Expression<Func<TSpecificationSubject, bool>> expression);
    }
}