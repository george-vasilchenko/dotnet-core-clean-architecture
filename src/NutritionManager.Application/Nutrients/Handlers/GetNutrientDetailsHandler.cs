using System;
using System.Threading.Tasks;
using NutritionManager.Application.Common;
using NutritionManager.Application.Nutrients.Queries;

namespace NutritionManager.Application.Nutrients.Handlers
{
    public class GetNutrientDetailsHandler: QueryHandlerBase<GetNutrientDetails, Nutrient>
    {
        private readonly IRepository<Nutrient, Guid> repository;

        public GetNutrientDetailsHandler(IRepository<Nutrient, Guid> repository)
        {
            this.repository = repository;
        }

        public override Task<Nutrient> HandleQueryAsync(GetNutrientDetails query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return this.repository.GetOneByKeyAsync(query.NutrientId);
        }
    }
}