using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using NutritionManager.Application.Nutrients;

namespace NutritionManager.Application.Test
{
    public class NutrientTest
    {
        [Test]
        public void Create_WithValidParams_CreatesNewInstance()
        {
            //Arrange
            var title = new Fixture().Create<string>();

            //Act
            INutrient instance = Nutrient.Create(title);

            //Assert
            instance.Should().NotBeNull();
            instance.Title.Should().Be(title);
        }

        [Test]
        public void Create_WithNullTitle_Throws()
        {
            //Arrange
            string? title = default;
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
            var title = string.Empty;
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
            var title = string.Empty;
            Action run = () => Nutrient.Create(title);

            //Act

            //Assert
            run.Should().ThrowExactly<ArgumentException>()
                .Where(e => e.Message.Contains(nameof(title)))
                .Where(e => e.Message.Contains("whitespace"));
        }
    }
}