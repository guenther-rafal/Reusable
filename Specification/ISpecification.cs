using System;
using System.Linq.Expressions;

namespace SmartFillCommon.Specification
{
    public interface ISpecification<TSpecificationSubject, TReturn>
    {
        TReturn IsSatisfied(TSpecificationSubject subject);
    }
}
