using System;
using System.Linq.Expressions;

namespace NutritionManager.Crosscutting
{
    public static class ExpressionHelper
    {
        public static Expression<Func<TTarget, bool>> Convert<TSource, TTarget>(Expression<Func<TSource, bool>> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var parameter = Expression.Parameter(typeof(TTarget), source.Parameters[0].Name);
            var body = new ParameterConverter(source.Parameters[0], parameter).Visit(source.Body);

            return Expression.Lambda<Func<TTarget, bool>>(body, parameter);
        }

        private class ParameterConverter : ExpressionVisitor
        {
            private readonly ParameterExpression source;

            private readonly ParameterExpression target;

            public ParameterConverter(ParameterExpression source, ParameterExpression target)
            {
                this.source = source;
                this.target = target;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return node == this.source ? this.target : base.VisitParameter(node);
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                return node.Expression == this.source
                    ? Expression.PropertyOrField(this.target, node.Member.Name)
                    : base.VisitMember(node);
            }
        }
    }
}