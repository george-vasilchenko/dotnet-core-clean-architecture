using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NutritionManager.Web.Models.Nutrients;
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

        public async Task<NutrientModel> GetNutrientAsync(Guid id)
        {
            var responseString = await this.httpClient
                .GetStringAsync(UrisProvider.NutrientDetails(id));

            if (string.IsNullOrWhiteSpace(responseString))
            {
                throw new InvalidOperationException("Something went wrong.");
            }

            return JsonConvert.DeserializeObject<NutrientModel>(responseString);
        }

        public Task CreateNutrientAsync(string title)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            var uri = UrisProvider.AddNutrient;
            var content = new CreateNutrientModel(title);
            return this.httpClient.PostAsJsonAsync(uri, content);
        }
        
        public Task DeleteNutrientAsync(Guid nutrientId)
        {
            var uri = UrisProvider.DeleteNutrient;
            var content = new DeleteNutrientModel(nutrientId);
            return this.httpClient.PostAsJsonAsync(uri, content);
        }

        public Task UpdateNutrientAsync(NutrientModel model)
        {
            var uri = UrisProvider.UpdateNutrient;
            var content = new UpdateNutrientModel(model.NutrientId, model.Title);
            return this.httpClient.PutAsJsonAsync(uri, content);
        }
    }
}