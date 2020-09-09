using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoFixture;
using FakeItEasy;
using NUnit.Framework;
using NutritionManager.Application.Nutrients;
using NutritionManager.Application.Nutrients.Commands;
using NutritionManager.Application.Nutrients.Handlers;
using NutritionManager.Application.Nutrients.Repositories;

namespace NutritionManager.Application.Test.Nutrients
{
    public class DeleteNutrientByTitleHandlerTest
    {
        private INutrientRepository repository;

        private DeleteNutrientByTitleHandler sut;

        [SetUp]
        public void Setup()
        {
            this.repository = A.Fake<INutrientRepository>();
            this.sut = new DeleteNutrientByTitleHandler(this.repository);
        }

        [Test]
        public async Task HandleCommandAsync_WithValidParams_DeletesNutrient()
        {
            // Arrange
            var title = new Fixture().Create<string>();
            var fakeNutrient = CreteFakeNutrient();
            var command = new DeleteNutrientByTitle(title);

            A.CallTo(() => this.repository.GetAsync(A<Expression<Func<Nutrient, bool>>>.Ignored))
                .Returns(Task.FromResult(fakeNutrient));

            // Act
            await this.sut.HandleCommandAsync(command);

            // Assert
            A.CallTo(() => this.repository.GetAsync(A<Expression<Func<Nutrient, bool>>>.Ignored))
                .MustHaveHappenedOnceExactly();
            A.CallTo(() => this.repository.UpdateAsync(fakeNutrient))
                .MustHaveHappenedOnceExactly();
        }

        private static Nutrient CreteFakeNutrient()
        {
            return Nutrient.Create(new Fixture().Create<string>());
        }
    }
}