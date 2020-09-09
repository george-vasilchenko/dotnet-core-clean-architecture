namespace NutritionManager.Application.Nutrients.Commands
{
    public class DeleteNutrientByTitle
    {
        public DeleteNutrientByTitle(string title)
        {
            this.Title = title;
        }

        public string Title { get; }
    }
}