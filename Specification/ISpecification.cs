using System;
using System.Linq.Expressions;

namespace Reusable.Specification
{
    public interface ISpecification<TSpecificationSubject, TReturn>
    {
        TReturn IsSatisfied(TSpecificationSubject subject);
    }
}
