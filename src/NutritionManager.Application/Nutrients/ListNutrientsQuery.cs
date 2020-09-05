using System;
using System.Linq.Expressions;

namespace NutritionManager.Application.Nutrients
{
    public class ListNutrientsQuery : IListNutrientsQuery
    {
        public Expression<Func<INutrient, bool>>[] Filter { get; }

        public ListNutrientsQuery(params Expression<Func<INutrient, bool>>[] filter)
        {
            this.Filter = filter;
        }
    }
}