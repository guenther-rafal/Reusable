using System;
using System.Linq.Expressions;

namespace SmartFillCommon.Specification.Builder
{
    public interface ICompositeSpecificationBuilder<TSpecificationSubject> : ISpecificationBuilderExtender<TSpecificationSubject>
    {
        ICompositeSpecificationBuilder<TSpecificationSubject> And(Expression<Func<TSpecificationSubject, bool>> expression);
        ICompositeSpecificationBuilder<TSpecificationSubject> Or(Expression<Func<TSpecificationSubject, bool>> expression);
        ICompositeSpecificationBuilder<TSpecificationSubject> AndIf(Expression<Func<TSpecificationSubject, bool>> expression, bool condition);
        ICompositeSpecificationBuilder<TSpecificationSubject> OrIf(Expression<Func<TSpecificationSubject, bool>> expression, bool condition);
    }
}