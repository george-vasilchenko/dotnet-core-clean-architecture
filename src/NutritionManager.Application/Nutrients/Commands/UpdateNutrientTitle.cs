using System;

namespace NutritionManager.Application.Nutrients.Commands
{
    public class UpdateNutrientTitle
    {
        public UpdateNutrientTitle(Guid nutrientId, string newTitle)
        {
            this.NutrientId = nutrientId;
            this.NewTitle = newTitle;
        }

        public Guid NutrientId { get; }

        public string NewTitle { get; }
    }
}