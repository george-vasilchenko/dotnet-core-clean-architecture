using System;
using System.Linq;
using System.Threading.Tasks;
using NutritionManager.Application.Nutrients.Commands;
using NutritionManager.Application.Nutrients.Repositories;

namespace NutritionManager.Application.Nutrients.Handlers
{
    public class CreateNutrientHandler
    {
        private readonly INutrientRepository repository;

        public CreateNutrientHandler(INutrientRepository repository)
        {
            this.repository = repository;
        }

        public async Task HandleCommandAsync(CreateNutrient command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var searchResults = await this.repository.FindAsync(n => n.Title == command.Title);
            var nutrient = searchResults.SingleOrDefault();
            
            if (nutrient != null)
            {
                throw new InvalidOperationException($"Nutrient with the title {nutrient.Title} already exists");
            }

            nutrient = Nutrient.Create(command.Title);

            await this.repository.AddAsync(nutrient);
        }
    }
}