using System.Linq;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using NutritionManager.Application.Nutrients;
using NutritionManager.DataStore.InMemory.Nutrients;

namespace NutritionManager.DataStore.Test.Compatibility
{
    public class CompatibilityTest
    {
        [Test]
        public void InMemory_Nutrient_IsCompatibleWith_NutrientModel()
        {
            // Arrange
            var nutrientPropertyNames =
                typeof(Nutrient).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Select(p => p.Name);
            var nutrientModelPropertyNames =
                typeof(NutrientModel).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Select(p => p.Name);

            var difference = nutrientPropertyNames.Except(nutrientModelPropertyNames).ToArray();

            // Assert
            difference.Should().BeEmpty();
        }

        // [Test]
        // public void MongoDb_Nutrient_IsCompatibleWith_NutrientModel()
        // {
        //     // Arrange
        //     var nutrientPropertyNames =
        //         typeof(Nutrient).GetProperties(BindingFlags.Instance | BindingFlags.Public)
        //             .Select(p => p.Name);
        //     var nutrientModelPropertyNames =
        //         typeof(Nutrients.Models.MongoDb.NutrientModel)
        //             .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        //             .Select(p => p.Name);
        //
        //     var difference = nutrientPropertyNames.Except(nutrientModelPropertyNames).ToArray();
        //
        //     // Assert
        //     difference.Should().BeEmpty();
        // }
    }
}