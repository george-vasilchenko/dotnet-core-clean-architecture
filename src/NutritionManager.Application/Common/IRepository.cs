using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NutritionManager.Application.Nutrients;

namespace NutritionManager.Application.Common
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class
    {
        Task<TEntity> GetOneByKeyAsync(TKey key);

        Task<Nutrient?> FindOneAsync(Expression<Func<TEntity, bool>> filter);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter);

        Task<TKey> InsertOneAsync(TEntity entity);

        Task RemoveOneByKeyAsync(TKey key);

        Task SaveOneAsync(TEntity entity);
    }
}