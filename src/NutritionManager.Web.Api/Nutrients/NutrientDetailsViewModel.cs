using System;
using NutritionManager.Application.Nutrients;

namespace NutritionManager.Web.Api.Nutrients
{
    public class NutrientDetailsViewModel
    {
        public Guid NutrientId { get; }

        public string Title { get; }

        public NutrientDetailsViewModel(Nutrient nutrient)
        {
            this.NutrientId = nutrient.NutrientId;
            this.Title = nutrient.Title;
        }
    }
}