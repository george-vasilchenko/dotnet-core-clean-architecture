using System;

namespace NutritionManager.Application.Nutrients
{
    public class Nutrient : INutrient
    {
        private Nutrient(string title)
        {
            this.Title = title;
        }

        public string Title { get; }

        public static INutrient Create(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace", nameof(title));
            }

            return new Nutrient(title);
        }
    }
}