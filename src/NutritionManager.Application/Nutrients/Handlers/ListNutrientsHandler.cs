using System.Collections.Generic;
using System.Threading.Tasks;
using NutritionManager.Application.Nutrients.Queries;
using NutritionManager.Application.Nutrients.Repositories;

namespace NutritionManager.Application.Nutrients.Handlers
{
    public class ListNutrientsHandler
    {
        private readonly INutrientRepository repository;

        public ListNutrientsHandler(INutrientRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<Nutrient>> HandleQueryAsync(ListNutrients query)
        {
            return this.repository.FindAsync(query.Filter);
        }
    }
}