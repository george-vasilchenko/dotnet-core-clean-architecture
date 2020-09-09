namespace NutritionManager.Application.Nutrients.Commands
{
    public class CreateNutrient
    {
        public CreateNutrient(string title)
        {
            this.Title = title;
        }

        public string Title { get; }
    }
}