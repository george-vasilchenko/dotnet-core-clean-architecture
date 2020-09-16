using System;
using System.Threading.Tasks;
using Blazorise;
using Microsoft.AspNetCore.Components;
using NutritionManager.Web.Wasm.Nutrient.Models;
using NutritionManager.Web.Wasm.Nutrient.Services;

namespace NutritionManager.Web.Wasm.Nutrient.Pages
{
    public partial class NutrientDetails
    {
        private NutrientModel model;

        [Inject]
        private NutrientValidationService ValidationService { get; set; }
        
        [Inject]
        private NutrientService Service { get; set; }

        [Parameter]
        public string NutrientId { get; set; }

        protected override Task OnInitializedAsync()
        {
            return this.RefreshAsync();
        }

        private async Task RefreshAsync()
        {
            this.model = await this.Service.GetNutrientAsync(Guid.Parse(this.NutrientId));
        }

        private async Task UpdateNutrientAsync()
        {
            await this.Service.UpdateNutrientAsync(this.model);
            await this.RefreshAsync();
        }
        
        private bool IsSaveButtonDisabled()
        {
            return this.model.Title == null || this.model.Title.Length <= 0;
        }
    }
}