using System;
using System.Linq.Expressions;

namespace NutritionManager.Application.Nutrients.Queries
{
    public class ListNutrients
    {
        public ListNutrients(Expression<Func<Nutrient, bool>> filter)
        {
            this.Filter = filter;
        }

        public Expression<Func<Nutrient, bool>> Filter { get; }
    }
}