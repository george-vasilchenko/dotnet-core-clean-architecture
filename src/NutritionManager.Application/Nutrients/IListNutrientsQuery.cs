using System;
using System.Linq.Expressions;

namespace NutritionManager.Application.Nutrients
{
    public interface IListNutrientsQuery
    {
        Expression<Func<INutrient, bool>>[] Filter { get; }
    }
}