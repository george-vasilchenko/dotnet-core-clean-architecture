using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using NutritionManager.Application.Common;
using NutritionManager.Application.Nutrients;
using NutritionManager.Application.Nutrients.Handlers;
using NutritionManager.Application.Nutrients.Queries;
using NutritionManager.Crosscutting.Templates;

namespace NutritionManager.Application.Test.Nutrients
{
    public class ListNutrientsHandlerTest
    {
        private IRepository<Nutrient, Guid> repository;

        private ListNutrientsHandler sut;

        [SetUp]
        public void Setup()
        {
            this.repository = A.Fake<IRepository<Nutrient, Guid>>();
            this.sut = new ListNutrientsHandler(this.repository);
        }

        [Test]
        public async Task HandleQueryAsync_WithValidArgs_ReturnsListOfNutrients()
        {
            // Arrange
            var allExpression = ExpressionTemplates.AllExpression<Nutrient>();
            var query = new ListNutrients(allExpression);

            const int nutrientsCount = 3;
            var nutrients = GetFakeNutrients(nutrientsCount);

            A.CallTo(() => this.repository.FindAsync(allExpression))
                .Returns(Task.FromResult(nutrients));

            // Act
            var result = await this.sut.HandleQueryAsync(query);

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();

            A.CallTo(() => this.repository.FindAsync(allExpression))
                .MustHaveHappenedOnceExactly();
        }

        private static IEnumerable<Nutrient> GetFakeNutrients(int nutrientsCount)
        {
            return Enumerable
                .Range(0, nutrientsCount)
                .Select(i => Nutrient.Create(new Fixture().Create<string>()));
        }
    }
}