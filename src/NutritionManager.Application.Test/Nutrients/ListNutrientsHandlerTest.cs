using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using NutritionManager.Application.Nutrients;

namespace NutritionManager.Application.Test.Nutrients
{
    public class ListNutrientsHandlerTest
    {
        private readonly ListNutrientsHandler sut;
        private readonly INutrientRepository repository;

        public ListNutrientsHandlerTest()
        {
            this.repository = A.Fake<INutrientRepository>();
            this.sut = new ListNutrientsHandler(this.repository);
        }

        [Test]
        public async Task HandleQueryAsync_WithValidArgs_ReturnsListOfNutrients()
        {
            // Arrange
            var query = GetFakeListNutrientsQuery();
            const int nutrientsCount = 3;
            var nutrients = GetFakeNutrients(nutrientsCount);
            A.CallTo(() => this.repository.FindAsync(query.Filter))
                .Returns(Task.FromResult(nutrients));

            // Act
            var result = await this.sut.HandleQueryAsync(query);

            // Assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();

            A.CallTo(() => this.repository.FindAsync(query.Filter))
                .MustHaveHappenedOnceExactly();
        }

        private static IEnumerable<INutrient> GetFakeNutrients(int nutrientsCount)
        {
            return Enumerable
                .Range(0, 3)
                .Select(i => Nutrient.Create(new Fixture().Create<string>()));
        }

        private static IListNutrientsQuery GetFakeListNutrientsQuery()
        {
            return new ListNutrientsQuery(o => o != null);
        }
    }
}