using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using NutritionManager.Crosscutting.Helpers;

namespace NutritionManager.DataStore.Common
{
    public abstract class RepositoryBase<TEntity, TModel>
        where TEntity : class
        where TModel : class
    {
        private readonly IMapper mapper;

        protected RepositoryBase(IMapper mapper)
        {
            this.mapper = mapper;
        }

        protected static Expression<Func<TModel, bool>> GetModelExpression(Expression<Func<TEntity, bool>> filter)
        {
            return ExpressionHelper.Convert<TEntity, TModel>(filter);
        }

        protected TModel ConvertToModel(TEntity entity)
        {
            return this.mapper.Map<TEntity, TModel>(entity);
        }

        protected TEntity ConvertToEntity(TModel model)
        {
            return this.mapper.Map<TModel, TEntity>(model);
        }

        protected Task<TModel> ConvertToModelAsync(TEntity entity)
        {
            return Task.FromResult(this.mapper.Map<TEntity, TModel>(entity));
        }

        protected Task<TEntity> ConvertToEntityAsync(TModel model)
        {
            return Task.FromResult(this.mapper.Map<TModel, TEntity>(model));
        }
    }
}