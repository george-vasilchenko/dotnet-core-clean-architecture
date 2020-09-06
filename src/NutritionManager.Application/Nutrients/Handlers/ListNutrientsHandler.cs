using System.Collections.Generic;
using System.Threading.Tasks;
using NutritionManager.Application.Interface.Nutrients;
using NutritionManager.Application.Interface.Nutrients.Repositories;
using NutritionManager.Application.Nutrients.Queries;

namespace NutritionManager.Application.Nutrients.Handlers
{
    public class ListNutrientsHandler
    {
        private INutrientRepository repository;

        public ListNutrientsHandler(INutrientRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<INutrient>> HandleQueryAsync(IListNutrientsQuery query)
        {
            return this.repository.FindAsync(query.Filter);
        }
    }
}