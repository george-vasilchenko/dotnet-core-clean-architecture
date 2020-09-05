namespace NutritionManager.Application.Nutrients
{
    public class CreateNutrientCommand : ICreateNutrientCommand
    {
        public CreateNutrientCommand(string title)
        {
            this.Title = title;
        }

        public string Title { get; }
    }
}