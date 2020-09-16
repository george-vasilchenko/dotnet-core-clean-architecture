using System;

namespace NutritionManager.Web.Wasm.Static
{
    public static class UrisProvider
    {
        public static readonly Func<Guid, string> NutrientDetails =
            nutrientId => $"{BaseApiUri}{ApiVersion}/nutrient?nutrientId={nutrientId}";

        public static readonly string AddNutrient = $"{BaseApiUri}{ApiVersion}/nutrient/add";

        public static readonly string DeleteNutrient = $"{BaseApiUri}{ApiVersion}/nutrient/delete";

        public static readonly string UpdateNutrient = $"{BaseApiUri}{ApiVersion}/nutrient/update";

        public static string NutrientsList => $"{BaseApiUri}{ApiVersion}/nutrient/list-all";

        private static string ApiVersion => "/v1";

        private static string BaseApiUri => "https://localhost:5011/api";
    }
}