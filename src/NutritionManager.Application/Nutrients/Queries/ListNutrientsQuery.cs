using System;
using System.Linq.Expressions;
using NutritionManager.Application.Interface.Nutrients;

namespace NutritionManager.Application.Nutrients.Queries
{
    public class ListNutrientsQuery : IListNutrientsQuery
    {
        public Expression<Func<INutrient, bool>> Filter { get; }

        public ListNutrientsQuery(Expression<Func<INutrient, bool>> filter)
        {
            this.Filter = filter;
        }
    }
}