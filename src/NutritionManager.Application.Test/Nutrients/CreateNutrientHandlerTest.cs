using System;
using System.Threading.Tasks;
using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;
using NutritionManager.Application.Nutrients;

namespace NutritionManager.Application.Test.Nutrients
{
    public class CreateNutrientHandlerTest
    {
        private readonly CreateNutrientHandler sut;
        private readonly INutrientRepository repository;

        public CreateNutrientHandlerTest()
        {
            this.repository = A.Fake<INutrientRepository>();
            this.sut = new CreateNutrientHandler(this.repository);
        }

        [Test]
        public async Task HandleCommandAsync_WithValidArgs_CreatesAndSavesNutrient()
        {
            // Arrange
            CreateNutrientCommand command = GetFakeCreateNutrientCommand();

            // Act
            await this.sut.HandleCommandAsync(command);

            // Assert
            A.CallTo(() => this.repository.SaveAsync(
                A<INutrient>.That.Matches(o => o.Title == command.Title)))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public void HandleCommandAsync_WithNullCommand_Throws()
        {
            // Arrange
            CreateNutrientCommand? command = default;

            // Act
            Func<Task> run = async () => await this.sut.HandleCommandAsync(command!);

            // Assert
            run.Should().ThrowExactly<ArgumentNullException>()
                .Where(e => e.Message.Contains(nameof(command)));
        }

        private static CreateNutrientCommand GetFakeCreateNutrientCommand()
        {
            var title = new Fixture().Create<string>();
            return new CreateNutrientCommand(title);
        }
    }
}