using System;
using NutritionManager.Application.Nutrients;

namespace NutritionManager.DataStore.Nutrients.Models
{
    public class NutrientModel
    {
        public NutrientModel()
        {
            this.Title = string.Empty;
        }

        public NutrientModel(Nutrient nutrient)
        {
            if (nutrient == null)
            {
                throw new ArgumentNullException(nameof(nutrient));
            }

            this.Title = nutrient.Title;
        }

        public string Title { get; set; }

        public bool IsDeleted { get; set; }
    }
}