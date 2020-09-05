using System.Threading.Tasks;

namespace NutritionManager.Application.Nutrients
{
    public class CreateNutrientHandler
    {
        private INutrientRepository repository;

        public CreateNutrientHandler(INutrientRepository repository)
        {
            this.repository = repository;
        }

        public Task HandleCommandAsync(ICreateNutrientCommand command)
        {
            if (command is null)
            {
                throw new System.ArgumentNullException(nameof(command));
            }

            var nutrient = Nutrient.Create(command.Title);

            return this.repository.SaveAsync(nutrient);
        }
    }
}