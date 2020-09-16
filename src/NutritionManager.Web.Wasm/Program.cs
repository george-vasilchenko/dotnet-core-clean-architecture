using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NutritionManager.Web.Wasm.Nutrient.Services;

namespace NutritionManager.Web.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            RegisterDependencies(builder);
            builder.RootComponents.Add<App>("app");
            RegisterServices(builder);

            var host = builder.Build();
            host.Services
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();
            
            await host.RunAsync();
        }

        private static void RegisterDependencies(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddBlazorise(options => { options.ChangeTextOnKeyPress = true; })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();
        }

        private static void RegisterServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped(sp => ConfigureHttpClient(builder));
            builder.Services.AddScoped<NutrientService>();
            builder.Services.AddScoped<NutrientValidationService>();
        }

        private static HttpClient ConfigureHttpClient(WebAssemblyHostBuilder builder)
        {
            return new HttpClient
                { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
        }
    }
}