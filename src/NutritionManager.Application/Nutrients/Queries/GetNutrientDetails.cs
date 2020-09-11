using System;

namespace NutritionManager.Application.Nutrients.Queries
{
    public class GetNutrientDetails
    {
        public Guid NutrientId { get; }

        public GetNutrientDetails(Guid nutrientId)
        {
            this.NutrientId = nutrientId;
        }
    }
}