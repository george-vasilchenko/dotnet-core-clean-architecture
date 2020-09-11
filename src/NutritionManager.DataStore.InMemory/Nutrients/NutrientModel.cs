using System;

namespace NutritionManager.DataStore.InMemory.Nutrients
{
    public class NutrientModel
    {
        public Guid NutrientId { get; set; }

        public string Title { get; set; } = string.Empty;

    }
}