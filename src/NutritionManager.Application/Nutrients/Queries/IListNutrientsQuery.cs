using System;
using System.Linq.Expressions;
using NutritionManager.Application.Interface.Nutrients;

namespace NutritionManager.Application.Nutrients.Queries
{
    public interface IListNutrientsQuery
    {
        Expression<Func<INutrient, bool>> Filter { get; }
    }
}