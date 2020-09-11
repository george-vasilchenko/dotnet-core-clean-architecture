using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NutritionManager.Web.Wasm.Nutrient;

namespace NutritionManager.Web.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => ConfigureHttpClient(builder));
            builder.Services.AddScoped<NutrientService>();

            await builder.Build().RunAsync();
        }

        private static HttpClient ConfigureHttpClient(WebAssemblyHostBuilder builder)
        {
            return new HttpClient
                { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
        }
    }
}