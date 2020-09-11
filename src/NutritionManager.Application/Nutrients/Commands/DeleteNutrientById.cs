using System;

namespace NutritionManager.Application.Nutrients.Commands
{
    public class DeleteNutrientById
    {
        public DeleteNutrientById(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; }
    }
}