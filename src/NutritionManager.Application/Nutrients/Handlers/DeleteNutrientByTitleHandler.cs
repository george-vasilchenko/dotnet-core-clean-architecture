using System;
using System.Threading.Tasks;
using NutritionManager.Application.Common;
using NutritionManager.Application.Nutrients.Commands;
using NutritionManager.Application.Nutrients.Repositories;

namespace NutritionManager.Application.Nutrients.Handlers
{
    public class DeleteNutrientByTitleHandler : CommandHandlerBase<DeleteNutrientByTitle>
    {
        private readonly INutrientRepository repository;

        public DeleteNutrientByTitleHandler(INutrientRepository repository)
        {
            this.repository = repository;
        }

        public override async Task HandleCommandAsync(DeleteNutrientByTitle command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var nutrient = await this.repository.GetAsync(o => o.Title == command.Title);
            nutrient.MarkDeleted();

            await this.repository.UpdateAsync(nutrient);
        }
    }
}