using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NutritionManager.Application.Common;
using NutritionManager.Application.Nutrients;
using NutritionManager.Application.Nutrients.Handlers;
using NutritionManager.DataStore.Mongo.Nutrients;

namespace NutritionManager.Web.Api
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
            services.AddCors(ConfigureCorsPolicy());
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Default");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static Action<CorsOptions> ConfigureCorsPolicy()
        {
            return opt =>
            {
                opt.AddPolicy("Default", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });
            };
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            // Nutrients
            services.AddScoped<CreateNutrientHandler>();
            services.AddScoped<ListNutrientsHandler>();
            services.AddScoped<DeleteNutrientByIdHandler>();
            services.AddScoped<GetNutrientDetailsHandler>();
            services.AddSingleton<IRepository<Nutrient, Guid>, NutrientRepository>();
        }
    }
}