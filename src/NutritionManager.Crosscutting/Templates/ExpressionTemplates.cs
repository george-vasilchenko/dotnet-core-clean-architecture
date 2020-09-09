using System;
using System.Linq.Expressions;

namespace NutritionManager.Crosscutting
{
    public static class ExpressionTemplates
    {
        public static Expression<Func<T, bool>> AllExpression<T>() where T : class
        {
            return o => o != null;
        }
    }
}