using Reusable.Specification.LogicalOperators;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Reusable.Specification.ExpressionExtension
{
    public static class ExpressionExtension
    {
        public static Expression<Func<TObject, bool>> And<TObject>(
            this Expression<Func<TObject, bool>> firstExpression, Expression<Func<TObject, bool>> secondExpression)
        {
            return firstExpression.Compose(secondExpression, Expression.And);
        }

        public static Expression<Func<TObject, bool>> Or<TObject>(
            this Expression<Func<TObject, bool>> firstExpression, Expression<Func<TObject, bool>> secondExpression)
        {
            return firstExpression.Compose(secondExpression, Expression.Or);
        }

        private static Expression<TObject> Compose<TObject>(this Expression<TObject> firstExpression, 
            Expression<TObject> secondExpression, Func<Expression, Expression, Expression> mergeFunction)
        {
            var map = firstExpression.Parameters
                .Select((first, i) => new { first, second = secondExpression.Parameters[i] })
                .ToDictionary(p => p.second, p => p.first);
            var secondExpressionBody = ParameterRebinder.Rebind(map, secondExpression.Body);
            var newExpressionBody = mergeFunction(firstExpression.Body, secondExpressionBody);
            return Expression.Lambda<TObject>(newExpressionBody, firstExpression.Parameters);
        }
    }
}
