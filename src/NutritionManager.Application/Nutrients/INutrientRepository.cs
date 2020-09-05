using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NutritionManager.Application.Nutrients
{
    public interface INutrientRepository
    {
        Task SaveAsync(INutrient nutrient);

        Task<IEnumerable<INutrient>> FindAsync(params Expression<Func<INutrient, bool>>[] filter);
    }
}