using System;
using System.Linq.Expressions;

namespace NutritionManager.Crosscutting.Templates
{
    public static class ExpressionTemplates
    {
        public static Expression<Func<T, bool>> AllExpression<T>() where T : class
        {
            return o => true;
        }
    }
}