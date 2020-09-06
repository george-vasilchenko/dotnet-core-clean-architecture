using System.Threading.Tasks;
using NutritionManager.Application.Nutrients.Handlers;
using NutritionManager.Application.Nutrients.Queries;
using NutritionManager.DataStore.Nutrients.Repositories;

namespace NutritionManager.Console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var repository = new InMemoryNutrientRepository();
            var handler = new ListNutrientsHandler(repository);
            var query = new ListNutrientsQuery(o => o.Title == "Fat");

            var result = await handler.HandleQueryAsync(query);

            System.Console.ReadKey();
        }
    }
}