using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace NutritionManager.Web.Wasm.Nutrient
{
    public partial class Nutrient
    {
        [Inject] public NutrientService Service { get; set; }

        public NutrientModelsList NutrientsList { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            this.NutrientsList = await this.Service.GetAllNutrients();
        }
    }
}