using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NutritionManager.Web.Wasm.Nutrient.Models;
using NutritionManager.Web.Wasm.Static;

namespace NutritionManager.Web.Wasm.Nutrient.Services
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
                .GetStringAsync(UrisProvider.NutrientsList);

            if (string.IsNullOrWhiteSpace(responseString))
            {
                throw new InvalidOperationException("Something went wrong.");
            }

            return JsonConvert.DeserializeObject<NutrientModelsList>(responseString);
        }

        public async Task<NutrientModel> GetNutrient(Guid id)
        {
            var responseString = await this.httpClient
                .GetStringAsync(UrisProvider.NutrientDetails(id));

            if (string.IsNullOrWhiteSpace(responseString))
            {
                throw new InvalidOperationException("Something went wrong.");
            }

            return JsonConvert.DeserializeObject<NutrientModel>(responseString);
        }
    }
}