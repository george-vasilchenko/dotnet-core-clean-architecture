using System;
using System.Collections.Generic;
using System.Linq;
using NutritionManager.Application.Nutrients;

namespace NutritionManager.Web.Api.Nutrients
{
    public class NutrientsListViewModel
    {
        public NutrientsListViewModel(IEnumerable<Nutrient> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            this.Items = ToViewModel(items);
        }

        public IEnumerable<NutrientListItemViewModel> Items { get; }

        private static IEnumerable<NutrientListItemViewModel> ToViewModel(IEnumerable<Nutrient> items)
        {
            return items.Select(i => new NutrientListItemViewModel(i));
        }
    }
}