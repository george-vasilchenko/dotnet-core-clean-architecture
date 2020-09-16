using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using MongoDB.Driver;
using NutritionManager.Application.Common;
using NutritionManager.Application.Nutrients;
using NutritionManager.DataStore.Common;

namespace NutritionManager.DataStore.Mongo.Nutrients
{
    public class NutrientRepository : RepositoryBase<Nutrient, NutrientModel>, IRepository<Nutrient, Guid>
    {
        private readonly IMongoCollection<NutrientModel> nutrients;

        public NutrientRepository()
            : base(ConfigureMapper())
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("nutrition-manager");

            this.nutrients = database.GetCollection<NutrientModel>("nutrient");
        }

        public async Task<Nutrient> GetOneByKeyAsync(Guid key)
        {
            var model = await this.nutrients
                .Find(n => n.NutrientId.Equals(key.ToString()))
                .SingleAsync();

            return await this.ConvertToEntityAsync(model);
        }

        public async Task<Nutrient?> FindOneAsync(Expression<Func<Nutrient, bool>> filter)
        {
            var modelExpression = GetModelExpression(filter);
            var model = await this.nutrients
                .Find(modelExpression)
                .SingleOrDefaultAsync();

            return model is null ? null : await this.ConvertToEntityAsync(model);
        }

        public async Task<Guid> InsertOneAsync(Nutrient entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var model = await this.ConvertToModelAsync(entity);

            await this.nutrients.InsertOneAsync(model);

            return entity.NutrientId;
        }

        public async Task RemoveOneByKeyAsync(Guid key)
        {
            await this.nutrients.DeleteOneAsync(n => n.NutrientId.Equals(key.ToString()));
        }

        public async Task SaveOneAsync(Nutrient entity)
        {
            var model = await this.ConvertToModelAsync(entity);
            await this.nutrients
                .ReplaceOneAsync(m => m.NutrientId.Equals(entity.NutrientId.ToString()), model);
        }

        public async Task<IEnumerable<Nutrient>> FindAsync(Expression<Func<Nutrient, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            var modelExpression = GetModelExpression(filter);
            var modelCollection = await this.nutrients.Find(modelExpression)
                .ToListAsync();

            return modelCollection.Select(this.ConvertToEntity);
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
    }
}