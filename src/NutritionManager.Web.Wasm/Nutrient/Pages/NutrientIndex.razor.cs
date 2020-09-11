using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using NutritionManager.Web.Wasm.Nutrient.Services;
using NutritionManager.Web.Wasm.Nutrient.Models;
using NutritionManager.Web.Wasm.Static;

namespace NutritionManager.Web.Wasm.Nutrient.Pages
{
    public partial class NutrientIndex
    {
        [Inject] private NutrientService Service { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        
        public NutrientModelsList NutrientsList { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            this.NutrientsList = await this.Service.GetAllNutrients();
        }

        public void OpenNutrientById(Guid nutrientId)
        {
            this.NavigationManager.NavigateTo(Routes.NutrientWithId(nutrientId));
        }
    }
}