using System;
using System.Threading.Tasks;
using Blazorise;
using Microsoft.AspNetCore.Components;
using NutritionManager.Web.Wasm.Nutrient.Services;

namespace NutritionManager.Web.Wasm.Nutrient.Pages
{    public partial class NewNutrient
    {
        private string newNutrientTitle = string.Empty;

        [Inject]
        private NutrientService Service { get; set; }
    
        [Parameter]
        public EventCallback OnFinishedEditing { get; set; }

        private async Task AddNutrientAsync()
        {
            await this.Service.CreateNutrientAsync(this.newNutrientTitle);
            await this.OnFinishedEditing.InvokeAsync(default);
        }

        private bool IsAddButtonDisabled()
        {
            return this.newNutrientTitle == null || this.newNutrientTitle.Length <= 0;
        }
        
        private static void ValidateTitle(ValidatorEventArgs eventArgs)
        {
            var value = eventArgs.Value?.ToString() ?? string.Empty;

            if (value.Length > 32)
            {
                eventArgs.Status = ValidationStatus.Error;
            }
        }
    }
}