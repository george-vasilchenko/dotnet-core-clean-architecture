using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NutritionManager.Web.Wasm.Nutrient
{
    public class NutrientService
    {
        private readonly HttpClient httpClient;

        public NutrientService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<NutrientModelsList> GetAllNutrients()
        {
            var responseString = await this.httpClient
                .GetStringAsync(@"https://localhost:5011/api/v1/nutrient/list-all");

            if (string.IsNullOrWhiteSpace(responseString))
            {
                throw new InvalidOperationException("Something went wrong.");
            }

            return JsonConvert.DeserializeObject<NutrientModelsList>(responseString);
        }
    }
}