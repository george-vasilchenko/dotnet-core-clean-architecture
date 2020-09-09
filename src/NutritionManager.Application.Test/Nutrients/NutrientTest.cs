using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using NutritionManager.Application.Nutrients;

namespace NutritionManager.Application.Test.Nutrients
{
    public class NutrientTest
    {
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
        }

        [Test]
        public void Create_WithNullTitle_Throws()
        {
            //Arrange
            const string? title = default;
            Action run = () => Nutrient.Create(title!);

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
        public void MarkDeleted_MarksAsDeleted()
        {
            // Arrange
            var instance = Nutrient.Create(new Fixture().Create<string>());

            //Act
            instance.MarkDeleted();

            //Assert
            instance.Should().NotBeNull();
            instance.IsDeleted.Should().BeTrue();
        }

        [Test]
        public void MarkDeleted_IsAlreadyDeleted_Throws()
        {
            // Arrange
            var instance = Nutrient.Create(new Fixture().Create<string>());
            instance.MarkDeleted();

            //Act
            Action run = () => instance.MarkDeleted();

            //Assert
            run.Should().ThrowExactly<InvalidOperationException>()
                .WithMessage("Nutrient is already deleted");
        }
    }
}