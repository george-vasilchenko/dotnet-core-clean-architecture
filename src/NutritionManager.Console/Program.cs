using System.Threading.Tasks;
using NutritionManager.Application.Nutrients.Commands;
using NutritionManager.Application.Nutrients.Handlers;
using NutritionManager.Application.Nutrients.Queries;
using NutritionManager.DataStore.Nutrients.Repositories;

namespace NutritionManager.Console
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var repository = new InMemoryNutrientRepository();
            var commandHandler = new CreateNutrientHandler(repository);
            var command = new CreateNutrient("Vitamin D");
            await commandHandler.HandleCommandAsync(command);

            var queryHandler = new ListNutrientsHandler(repository);
            var query = new ListNutrients(o => o.Title == "Vitamin D");
            var result = await queryHandler.HandleQueryAsync(query);

            System.Console.ReadKey();
        }
    }
}