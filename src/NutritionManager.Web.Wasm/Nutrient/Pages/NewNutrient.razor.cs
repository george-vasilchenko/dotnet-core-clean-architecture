using System.Threading.Tasks;
using Blazorise;
using Microsoft.AspNetCore.Components;
using NutritionManager.Web.Wasm.Nutrient.Services;

namespace NutritionManager.Web.Wasm.Nutrient.Pages
{
    public partial class NewNutrient
    {
        private string newNutrientTitle = string.Empty;

        [Inject]
        private NutrientValidationService ValidationService { get; set; }

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
    }
}