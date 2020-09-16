using System;
using System.Threading.Tasks;
using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using NutritionManager.Application.Common;
using NutritionManager.Application.Nutrients;
using NutritionManager.Application.Nutrients.Handlers;
using NutritionManager.Application.Nutrients.Queries;

namespace NutritionManager.Application.Test.Nutrients
{
    public class GetNutrientDetailsHandlerTest
    {
        private IRepository<Nutrient, Guid> repository;

        private GetNutrientDetailsHandler sut;
        
        
        public GetNutrientDetailsHandlerTest()
        {
            this.repository = A.Fake<IRepository<Nutrient, Guid>>();
            this.sut = new GetNutrientDetailsHandler(this.repository);
        }

        [Test]
        public async Task HandleQueryAsync_WithValidParams_ReturnsNutrient()
        {
            // Arrange
            var id = new Fixture().Create<Guid>();
            var query = new GetNutrientDetails(id);
            var fakeNutrient = Nutrient.Create(new Fixture().Create<string>());

            A.CallTo(() => this.repository.GetOneByKeyAsync(id))
                .Returns(fakeNutrient);

            // Act
            var result = await this.sut.HandleQueryAsync(query);

            // Assert
            result.Should().NotBeNull();
            A.CallTo(() => this.repository.GetOneByKeyAsync(id))
                .MustHaveHappenedOnceExactly();
        }
        
        [Test]
        public void HandleQueryAsync_WithNullQuery_Throws()
        {
            // Arrange
            GetNutrientDetails query = default!;

            // Act
            Func<Task> run = () => this.sut.HandleQueryAsync(query!);

            // Assert
            run.Should().ThrowExactly<ArgumentNullException>()
                .Where(e => e.Message.Contains(nameof(query)));
        }
    }
}