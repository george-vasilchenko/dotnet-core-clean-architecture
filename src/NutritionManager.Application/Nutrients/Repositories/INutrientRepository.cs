using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NutritionManager.Application.Nutrients.Repositories
{
    public interface INutrientRepository
    {
        Task<IEnumerable<Nutrient>> FindAsync(Expression<Func<Nutrient, bool>> filter);

        Task AddAsync(Nutrient nutrient);

        Task<Nutrient> GetAsync(Expression<Func<Nutrient, bool>> filter);

        Task UpdateAsync(Nutrient nutrient);
    }
}