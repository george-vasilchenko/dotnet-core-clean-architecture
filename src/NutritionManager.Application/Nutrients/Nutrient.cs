﻿using System;

namespace NutritionManager.Application.Nutrients
{
    public class Nutrient
    {
        private Nutrient()
        {
        }

        private Nutrient(Guid nutrientId, string title)
        {
            this.NutrientId = nutrientId;
            this.Title = title;
        }

        public string Title { get; private set; } = string.Empty;

        public Guid NutrientId { get; }

        public static Nutrient Create(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace", nameof(title));
            }

            return new Nutrient(Guid.NewGuid(), title);
        }

        public void ChangeTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(newTitle));
            }

            this.Title = newTitle;
        }
    }
}