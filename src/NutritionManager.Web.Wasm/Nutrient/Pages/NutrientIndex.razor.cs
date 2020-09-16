using System;
using System.Threading.Tasks;
using Blazorise;
using Microsoft.AspNetCore.Components;
using NutritionManager.Web.Wasm.Nutrient.Models;
using NutritionManager.Web.Wasm.Nutrient.Services;
using NutritionManager.Web.Wasm.Static;

namespace NutritionManager.Web.Wasm.Nutrient.Pages
{
    public partial class NutrientIndex
    {
        private NutrientModelsList model;

        [Inject]
        private NutrientService Service { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        protected override Task OnInitializedAsync()
        {
            return this.RefreshAsync();
        }

        private async Task RefreshAsync()
        {
            this.model = await this.Service.GetAllNutrients();
        }

        private void OpenNutrientById(Guid nutrientId)
        {
            this.NavigationManager.NavigateTo(Routes.NutrientWithId(nutrientId));
        }

        private async Task DeleteNutrientAsync(Guid nutrientId)
        {
            await this.Service.DeleteNutrientAsync(nutrientId);
            await this.RefreshAsync();
        }
    }
}