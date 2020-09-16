using System;

namespace NutritionManager.Web.Models.Nutrients
{
    public class DeleteNutrientModel
    {
        public DeleteNutrientModel(Guid nutrientId)
        {
            this.NutrientId = nutrientId;
        }

        public Guid NutrientId { get; }
    }
}