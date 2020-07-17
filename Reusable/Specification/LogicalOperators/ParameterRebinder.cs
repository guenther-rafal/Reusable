using System.Collections.Generic;
using System.Linq.Expressions;

namespace Reusable.Specification.LogicalOperators
{
    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly IDictionary<ParameterExpression, ParameterExpression> _parameterMap;

        public ParameterRebinder(IDictionary<ParameterExpression, ParameterExpression> parameterMap)
        {
            _parameterMap = parameterMap ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        public static Expression Rebind(IDictionary<ParameterExpression, ParameterExpression> parameterMap, Expression expression)
        {
            var rebinder = new ParameterRebinder(parameterMap);
            return rebinder.Visit(expression);
        }

        protected override Expression VisitParameter(ParameterExpression parameter)
        {
            if (_parameterMap.TryGetValue(parameter, out ParameterExpression replacement))
            {
                parameter = replacement;
            }
            return base.VisitParameter(parameter);
        }
    }
}
