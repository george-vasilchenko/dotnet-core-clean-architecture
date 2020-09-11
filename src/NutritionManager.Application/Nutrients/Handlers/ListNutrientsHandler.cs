using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NutritionManager.Application.Common;
using NutritionManager.Application.Nutrients.Queries;

namespace NutritionManager.Application.Nutrients.Handlers
{
    public class ListNutrientsHandler
    {
        private readonly IRepository<Nutrient, Guid> repository;

        public ListNutrientsHandler(IRepository<Nutrient, Guid> repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<Nutrient>> HandleQueryAsync(ListNutrients query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return this.repository.FindAsync(query.Filter);
        }
    }
}