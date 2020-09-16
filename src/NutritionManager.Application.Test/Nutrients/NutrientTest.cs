using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using NutritionManager.Application.Nutrients;

namespace NutritionManager.Application.Test.Nutrients
{
    public class NutrientTest
    {
        private IFixture fixture;
        
        [SetUp]
        public void Setup()
        {
            this.fixture = new Fixture();
        }
        
        [Test]
        public void Create_WithValidParams_CreatesNewInstance()
        {
            //Arrange
            var title = new Fixture().Create<string>();

            //Act
            var instance = Nutrient.Create(title);

            //Assert
            instance.Should().NotBeNull();
            instance.Title.Should().Be(title);
            instance.NutrientId.Should().NotBe(Guid.Empty);
        }

        [Test]
        public void Create_WithNullTitle_Throws()
        {
            //Arrange
            const string title = default;
            Action run = () => Nutrient.Create(title);

            //Act

            //Assert
            run.Should().ThrowExactly<ArgumentException>()
                .Where(e => e.Message.Contains(nameof(title)));
        }

        [Test]
        public void Create_WithEmptyTitle_Throws()
        {
            //Arrange
            const string title = "";
            Action run = () => Nutrient.Create(title);

            //Act

            //Assert
            run.Should().ThrowExactly<ArgumentException>()
                .Where(e => e.Message.Contains(nameof(title)));
        }

        [Test]
        public void Create_WithWhitespaceTitle_Throws()
        {
            //Arrange
            const string title = "";
            Action run = () => Nutrient.Create(title);

            //Act

            //Assert
            run.Should().ThrowExactly<ArgumentException>()
                .Where(e => e.Message.Contains(nameof(title)))
                .Where(e => e.Message.Contains("whitespace"));
        }

        [Test]
        public void ChangeTitle_WithValidArgs_ChangesTitle()
        {
            // Arrange
            var newTitle = this.fixture.Create<string>();
            var oldTitle = this.fixture.Create<string>();
            var nutrient = Nutrient.Create(oldTitle);

            // Act
            nutrient.ChangeTitle(newTitle);

            // Assert
            nutrient.Title.Should().BeEquivalentTo(newTitle);
        }
        
        [Test]
        public void ChangeTitle_WithEmptyTitle_Throws()
        {
            // Arrange
            var nutrient = Nutrient.Create(this.fixture.Create<string>());
            var newTitle = string.Empty;

            // Act
            Action run = () => nutrient.ChangeTitle(newTitle);

            // Assert
            run.Should().ThrowExactly<ArgumentException>()
                .Where(e => e.Message.Contains("newTitle"));
        }
        
        
        [Test]
        public void ChangeTitle_WithWhitespaceTitle_Throws()
        {
            // Arrange
            var nutrient = Nutrient.Create(this.fixture.Create<string>());
            const string newTitle = "  ";

            // Act
            Action run = () => nutrient.ChangeTitle(newTitle);

            // Assert
            run.Should().ThrowExactly<ArgumentException>()
                .Where(e => e.Message.Contains("newTitle"));
        }
        
        
        [Test]
        public void ChangeTitle_WithNullTitle_Throws()
        {
            // Arrange
            var nutrient = Nutrient.Create(this.fixture.Create<string>());
            const string newTitle = default!;

            // Act
            Action run = () => nutrient.ChangeTitle(newTitle!);

            // Assert
            run.Should().ThrowExactly<ArgumentException>()
                .Where(e => e.Message.Contains("newTitle"));
        }
    }
}