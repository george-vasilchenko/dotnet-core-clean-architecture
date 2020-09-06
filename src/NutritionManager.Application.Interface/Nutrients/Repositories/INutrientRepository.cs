using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NutritionManager.Application.Interface.Nutrients.Repositories
{
    public interface INutrientRepository
    {
        Task SaveAsync(INutrient nutrient);

        Task<IEnumerable<INutrient>> FindAsync(Expression<Func<INutrient, bool>> filter);
    }
}