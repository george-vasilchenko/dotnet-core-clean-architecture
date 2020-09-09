using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NutritionManager.Application.Nutrients;
using NutritionManager.Application.Nutrients.Repositories;
using NutritionManager.Crosscutting;
using NutritionManager.DataStore.Mappings;
using NutritionManager.DataStore.Nutrients.Models;

namespace NutritionManager.DataStore.Nutrients.Repositories
{
    public class InMemoryNutrientRepository : INutrientRepository
    {
        private readonly MappingAdapter mapper;

        private readonly List<NutrientModel> models;

        public InMemoryNutrientRepository()
        {
            this.models = InitializeModels();
            this.mapper = ConfigureMapper();
        }

        private IQueryable<NutrientModel> ModelsQueryable => this.models.AsQueryable();

        public Task<IEnumerable<Nutrient>> FindAsync(Expression<Func<Nutrient, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            var modelExpression = GetModelExpression(filter);
            var modelCollection = this.ModelsQueryable.Where(modelExpression).ToList();
            var result = modelCollection.Select(m => this.mapper.Convert<NutrientModel, Nutrient>(m));

            return Task.FromResult(result.AsEnumerable());
        }

        public Task<Nutrient> GetAsync(Expression<Func<Nutrient, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            var modelExpression = GetModelExpression(filter);
            var model = this.ModelsQueryable.Single(modelExpression);
            var result = this.mapper.Convert<NutrientModel, Nutrient>(model);

            return Task.FromResult(result);
        }

        public Task UpdateAsync(Nutrient nutrient)
        {
            if (nutrient == null)
            {
                throw new ArgumentNullException(nameof(nutrient));
            }

            var model = this.models.Single(n => n.Title == nutrient.Title);
            var index = this.models.IndexOf(model);
            this.models[index] = this.mapper.Convert<Nutrient, NutrientModel>(nutrient);

            return Task.CompletedTask;
        }

        public Task AddAsync(Nutrient nutrient)
        {
            if (nutrient == null)
            {
                throw new ArgumentNullException(nameof(nutrient));
            }

            var model = this.mapper.Convert<Nutrient, NutrientModel>(nutrient);
            this.models.Add(model);

            return Task.CompletedTask;
        }

        private static MappingAdapter ConfigureMapper()
        {
            var mapping = new Dictionary<Type, Type>
            {
                { typeof(Nutrient), typeof(NutrientModel) },
                { typeof(NutrientModel), typeof(Nutrient) }
            };

            return new MappingAdapter(mapping);
        }

        private static List<NutrientModel> InitializeModels()
        {
            return new List<NutrientModel>
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
            };
        }

        private static Expression<Func<NutrientModel, bool>> GetModelExpression(Expression<Func<Nutrient, bool>> filter)
        {
            return ExpressionHelper.Convert<Nutrient, NutrientModel>(filter);
        }
    }
}