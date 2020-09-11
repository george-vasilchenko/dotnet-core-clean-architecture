using System;

namespace NutritionManager.Web.Wasm.Static
{
    public static class Routes
    {
        public static string NutrientIndex => "/nutrient";
        public static readonly Func<Guid, string> NutrientWithId = nutrientId => $"/nutrient/{nutrientId}";
    }
}