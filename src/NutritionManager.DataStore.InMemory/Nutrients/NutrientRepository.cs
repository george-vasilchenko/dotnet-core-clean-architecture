using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using NutritionManager.Application.Common;
using NutritionManager.Application.Nutrients;
using NutritionManager.DataStore.Common;

namespace NutritionManager.DataStore.InMemory.Nutrients
{
    public class NutrientRepository : RepositoryBase<Nutrient, NutrientModel>, IRepository<Nutrient, Guid>
    {
        private readonly List<NutrientModel> models;

        public NutrientRepository()
            : base(ConfigureMapper())
        {
            this.models = InitializeStaticModels();
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
            var result = modelCollection.Select(this.ConvertToEntity);

            return Task.FromResult(result.AsEnumerable());
        }

        public async Task<Nutrient> GetOneByKeyAsync(Guid key)
        {
            var model = this.models
                .Single(n => n.Id.Equals(key));

            return await this.ConvertToEntityAsync(model);
        }

        public Task<Nutrient?> FindOneAsync(Expression<Func<Nutrient, bool>> filter)
        {
            var modelExpression = GetModelExpression(filter);
            var model = this.ModelsQueryable
                .Where(modelExpression)
                .SingleOrDefault();

            return (model != null
                ? Task.FromResult(this.ConvertToEntity(model))
                : Task.FromResult<Nutrient?>(null)!)!;
        }

        public Task<Guid> InsertOneAsync(Nutrient entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var model = this.ConvertToModel(entity);
            this.models.Add(model);

            return Task.FromResult(model.Id);
        }

        public Task RemoveOneByKeyAsync(Guid key)
        {
            var model = this.models.Single(n => n.Id.Equals(key));
            var indexInCollection = this.models.IndexOf(model);

            this.models.RemoveAt(indexInCollection);

            return Task.CompletedTask;
        }

        public Task SaveOneAsync(Nutrient entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var model = this.models.Single(n => n.Id == entity.Id);
            var index = this.models.IndexOf(model);
            this.models[index] = this.ConvertToModel(entity);

            return Task.CompletedTask;
        }

        private static IMapper ConfigureMapper()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Nutrient, NutrientModel>();
                config.CreateMap<NutrientModel, Nutrient>();
            });

            return new Mapper(mappingConfig);
        }

        private static List<NutrientModel> InitializeStaticModels()
        {
            return new List<NutrientModel>
            {
                new NutrientModel
                {
                    Id = Guid.Parse("fdb6cf76-7383-45ec-9344-ddde0c17f1c8"),
                    Title = "Carbohydrate"
                },
                new NutrientModel
                {
                    Id = Guid.Parse("6a41ba84-48bc-4eaf-a2b6-a7d262cf79c4"),
                    Title = "Protein"
                },
                new NutrientModel
                {
                    Id = Guid.Parse("a481664d-0044-481c-97cb-fe9fc37973f6"),
                    Title = "Fat"
                }
            };
        }
    }
}