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

            this.Title = nutrient.Title;
            this.IsDeleted = nutrient.IsDeleted;
        }

        public string Title { get; }

        public bool IsDeleted { get; }
    }
}