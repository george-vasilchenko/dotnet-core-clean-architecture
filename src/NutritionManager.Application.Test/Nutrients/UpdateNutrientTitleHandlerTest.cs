using System;
using System.Threading.Tasks;
using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using NutritionManager.Application.Common;
using NutritionManager.Application.Nutrients;
using NutritionManager.Application.Nutrients.Commands;
using NutritionManager.Application.Nutrients.Handlers;

namespace NutritionManager.Application.Test.Nutrients
{
    public class UpdateNutrientTitleHandlerTest
    {
        private IFixture fixture;

        private IRepository<Nutrient, Guid> repository;

        private UpdateNutrientTitleHandler sut;

        [SetUp]
        public void Setup()
        {
            this.repository = A.Fake<IRepository<Nutrient, Guid>>();
            this.sut = new UpdateNutrientTitleHandler(this.repository);
            this.fixture = new Fixture();
        }

        [Test]
        public async Task HandleCommandAsync_WithValidArgs_UpdatesNutrientTitle()
        {
            // Arrange
            var id = this.fixture.Create<Guid>();
            var newTitle = this.fixture.Create<string>();
            var oldTitle = this.fixture.Create<string>();
            var command = new UpdateNutrientTitle(id, newTitle);
            var fakeNutrient = Nutrient.Create(oldTitle);

            A.CallTo(() => this.repository.GetOneByKeyAsync(id))
                .Returns(fakeNutrient);
            
            // Act
            await this.sut.HandleCommandAsync(command);

            // Assert
            A.CallTo(() => this.repository.GetOneByKeyAsync(id))
                .MustHaveHappenedOnceExactly();
            A.CallTo(() => this.repository.SaveOneAsync(fakeNutrient))
                .MustHaveHappenedOnceExactly();
            fakeNutrient.Title.Should().BeEquivalentTo(newTitle);
        }

        [Test]
        public void HandleCommandAsync_WithNullCommand_Throws()
        {
            // Arrange
            var command = default(UpdateNutrientTitle);
            
            // Act
            Func<Task> run = async () => await this.sut.HandleCommandAsync(command!);
            
            // Assert
            run.Should().ThrowExactly<ArgumentNullException>()
                .And.ParamName.Should().BeEquivalentTo(nameof(command));
        }
    }
}