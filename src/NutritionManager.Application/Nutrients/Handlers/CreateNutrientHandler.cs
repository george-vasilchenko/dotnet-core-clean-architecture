using System;
using System.Threading.Tasks;
using NutritionManager.Application.Common;
using NutritionManager.Application.Nutrients.Commands;

namespace NutritionManager.Application.Nutrients.Handlers
{
    public class CreateNutrientHandler
    {
        private readonly IRepository<Nutrient, Guid> repository;

        public CreateNutrientHandler(IRepository<Nutrient, Guid> repository)
        {
            this.repository = repository;
        }

        public async Task HandleCommandAsync(CreateNutrient command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var nutrient = await this.repository.FindOneAsync(n => n.Title.Equals(command.Title));

            if (nutrient != null)
            {
                throw new InvalidOperationException($"Nutrient with the title {nutrient.Title} already exists");
            }

            nutrient = Nutrient.Create(command.Title);

            await this.repository.InsertOneAsync(nutrient);
        }
    }
}