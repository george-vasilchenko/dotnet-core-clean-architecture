using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NutritionManager.Application.Nutrients.Handlers;
using NutritionManager.Application.Nutrients.Repositories;
using NutritionManager.DataStore.Nutrients.Repositories;

namespace NutritionManager.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            RegisterApplicationServices(services);
            services.AddControllers()
                .AddNewtonsoftJson();
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            // Nutrients
            services.AddScoped<CreateNutrientHandler>();
            services.AddScoped<ListNutrientsHandler>();
            services.AddScoped<DeleteNutrientByTitleHandler>();
            services.AddSingleton<INutrientRepository, InMemoryNutrientRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}