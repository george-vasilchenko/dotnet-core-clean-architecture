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

            this.Id = nutrient.Id;
            this.Title = nutrient.Title;
            this.IsDeleted = nutrient.IsDeleted;
        }

        public Guid Id { get; }

        public string Title { get; }

        public bool IsDeleted { get; }
    }
}