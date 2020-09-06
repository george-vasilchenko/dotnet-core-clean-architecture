using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NutritionManager.Application.Interface.Nutrients;
using NutritionManager.Application.Interface.Nutrients.Repositories;
using NutritionManager.DataStore.Nutrients.Models;

namespace NutritionManager.DataStore.Nutrients.Repositories
{
    public class InMemoryNutrientRepository : INutrientRepository
    {
        private readonly IQueryable<INutrient> nutrients = new NutrientModel[]
        {
            new NutrientModel
            {
                Title = "Carbohydrate"
            },
            new NutrientModel
            {
                Title = "Protein"
            },
            new NutrientModel
            {
                Title = "Fat"
            }
        }.AsQueryable();

        public Task<IEnumerable<INutrient>> FindAsync(Expression<Func<INutrient, bool>> filter)
        {
            if (filter != null)
            {
                var result = this.nutrients.Where(filter).ToList();
                return Task.FromResult(result.AsEnumerable());
            }

            return Task.FromResult(this.nutrients.ToList().AsEnumerable());
        }

        public Task SaveAsync(INutrient nutrient)
        {
            return Task.CompletedTask;
        }
    }
}