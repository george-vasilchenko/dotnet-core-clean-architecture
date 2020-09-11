using System;

namespace NutritionManager.Application.Nutrients
{
    public class Nutrient
    {
        private Nutrient()
        {
        }

        public string Title { get; private set; } = string.Empty;

        public bool IsDeleted { get; private set; }

        public Guid Id { get; private set; }

        public void MarkDeleted()
        {
            if (this.IsDeleted)
            {
                throw new InvalidOperationException("Nutrient is already deleted");
            }

            this.IsDeleted = true;
        }

        public static Nutrient Create(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace", nameof(title));
            }

            return new Nutrient
            {
                Title = title,
                Id = Guid.NewGuid()
            };
        }
    }
}