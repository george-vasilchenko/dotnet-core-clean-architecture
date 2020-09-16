using System;

namespace NutritionManager.Web.Models.Nutrients
{
    public class UpdateNutrientModel
    {
        public UpdateNutrientModel(Guid nutrientId, string title)
        {
            this.NutrientId = nutrientId;
            this.Title = title;
        }

        public Guid NutrientId { get; }

        public string Title { get; }
    }
}