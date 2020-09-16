using System;
using System.Threading.Tasks;
using NutritionManager.Application.Common;
using NutritionManager.Application.Nutrients.Commands;

namespace NutritionManager.Application.Nutrients.Handlers
{
    public class UpdateNutrientTitleHandler: CommandHandlerBase<UpdateNutrientTitle>
    {
        private readonly IRepository<Nutrient, Guid> repository;

        public UpdateNutrientTitleHandler(IRepository<Nutrient,Guid> repository)
        {
            this.repository = repository;
        }

        public override async Task HandleCommandAsync(UpdateNutrientTitle command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var nutrient = await this.repository.GetOneByKeyAsync(command.NutrientId);
            nutrient.ChangeTitle(command.NewTitle);

            await this.repository.SaveOneAsync(nutrient);
        }
    }
}