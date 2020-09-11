using System;
using System.Threading.Tasks;
using NutritionManager.Application.Common;
using NutritionManager.Application.Nutrients.Commands;

namespace NutritionManager.Application.Nutrients.Handlers
{
    public class DeleteNutrientByIdHandler : CommandHandlerBase<DeleteNutrientById>
    {
        private readonly IRepository<Nutrient, Guid> repository;

        public DeleteNutrientByIdHandler(IRepository<Nutrient, Guid> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleCommandAsync(DeleteNutrientById command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            await this.repository.RemoveOneByKeyAsync(command.Id);
        }
    }
}