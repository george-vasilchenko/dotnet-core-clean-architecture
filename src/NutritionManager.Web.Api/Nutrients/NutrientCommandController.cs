using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutritionManager.Application.Nutrients.Commands;
using NutritionManager.Application.Nutrients.Handlers;
using NutritionManager.Web.Models.Nutrients;

namespace NutritionManager.Web.Api.Nutrients
{
    [ApiController]
    [Route("/api/v1/nutrient")]
    public class NutrientCommandController : Controller
    {
        private readonly CreateNutrientHandler createNutrientHandler;

        private readonly DeleteNutrientByIdHandler deleteNutrientByIdHandler;

        private readonly UpdateNutrientTitleHandler updateNutrientTitleHandler;

        public NutrientCommandController(
            CreateNutrientHandler createNutrientHandler,
            DeleteNutrientByIdHandler deleteNutrientByIdHandler,
            UpdateNutrientTitleHandler updateNutrientTitleHandler)
        {
            this.createNutrientHandler = createNutrientHandler;
            this.deleteNutrientByIdHandler = deleteNutrientByIdHandler;
            this.updateNutrientTitleHandler = updateNutrientTitleHandler;
        }
        
        [HttpPost("add")]
        public Task Add([FromBody] CreateNutrientModel model)
        {
            this.TryValidateModel(model);
            
            var command = new CreateNutrient(model.Title);

            return this.createNutrientHandler.HandleCommandAsync(command);
        }

        [HttpPost("delete")]
        public Task Delete([FromBody] DeleteNutrientModel model)
        {
            this.TryValidateModel(model);
            
            var command = new DeleteNutrientById(model.NutrientId);

            return this.deleteNutrientByIdHandler.HandleCommandAsync(command);
        }
        
        [HttpPut("update")]
        public Task Delete([FromBody] UpdateNutrientModel model)
        {
            this.TryValidateModel(model);

            var command = new UpdateNutrientTitle(model.NutrientId, model.Title);

            return this.updateNutrientTitleHandler.HandleCommandAsync(command);
        }
    }
}