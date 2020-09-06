using NutritionManager.Application.Interface.Nutrients;

namespace NutritionManager.DataStore.Nutrients.Models
{
    public class NutrientModel : INutrient
    {
        public string Title { get; set; } = string.Empty;
    }
}