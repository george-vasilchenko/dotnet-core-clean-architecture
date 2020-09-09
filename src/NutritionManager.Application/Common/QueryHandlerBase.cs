using System.Threading.Tasks;

namespace NutritionManager.Application.Common
{
    public abstract class QueryHandlerBase<TQuery, TResult>
        where TQuery : class
        where TResult : class
    {
        public abstract Task<TResult> HandleQueryAsync(TQuery query);
    }
}