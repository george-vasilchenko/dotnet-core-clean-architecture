using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace NutritionManager.Web.Models.Nutrients
{
    public class CreateNutrientModel
    {
        public CreateNutrientModel(string title)
        {
            this.Title = title;
        }

        [Required]
        public string Title { get; }
    }
}