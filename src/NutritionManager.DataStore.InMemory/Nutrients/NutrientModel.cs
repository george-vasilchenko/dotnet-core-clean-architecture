using System;

namespace NutritionManager.DataStore.InMemory.Nutrients
{
    public class NutrientModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
    }
}