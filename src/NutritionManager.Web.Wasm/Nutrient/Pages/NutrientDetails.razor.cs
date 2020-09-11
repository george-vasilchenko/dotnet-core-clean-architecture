using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using NutritionManager.Web.Wasm.Nutrient.Models;
using NutritionManager.Web.Wasm.Nutrient.Services;

namespace NutritionManager.Web.Wasm.Nutrient.Pages
{
    public partial class NutrientDetails
    {
        [Inject] private NutrientService Service { get; set; }

        [Parameter] public string NutrientId { get; set; }

        public NutrientModel Nutrient { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            this.Nutrient = await this.Service.GetNutrient(Guid.Parse(this.NutrientId));
        }
    }
}