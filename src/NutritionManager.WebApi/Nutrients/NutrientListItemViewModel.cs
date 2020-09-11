using System;
using NutritionManager.Application.Nutrients;

namespace NutritionManager.WebApi.Nutrients
{
    public class NutrientListItemViewModel
    {
        public NutrientListItemViewModel(Nutrient nutrient)
        {
            if (nutrient == null)
            {
                throw new ArgumentNullException(nameof(nutrient));
            }

            this.NutrientId = nutrient.NutrientId;
            this.Title = nutrient.Title;
        }

        public Guid NutrientId { get; }

        public string Title { get; }
    }
}