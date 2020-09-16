using System;

namespace NutritionManager.Web.Wasm.Nutrient.Models
{
    public class NutrientModel
    {
        public string Title { get; set; } = string.Empty;

        public Guid NutrientId { get; set; }
    }
}