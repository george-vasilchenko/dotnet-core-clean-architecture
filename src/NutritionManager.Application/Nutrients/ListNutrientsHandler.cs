using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionManager.Application.Nutrients
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