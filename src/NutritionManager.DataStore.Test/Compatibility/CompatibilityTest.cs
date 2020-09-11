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
        public void InMemory_NutrientModel_IsCompatibleWith_Nutrient()
        {
            // Arrange
            var nutrientPropertyNames =
                typeof(Nutrient).GetProperties(GetPropertyBindingFlags())
                    .Select(p => p.Name);
            var nutrientModelPropertyNames =
                typeof(NutrientModel).GetProperties(GetPropertyBindingFlags())
                    .Select(p => p.Name);

            var difference = nutrientPropertyNames.Except(nutrientModelPropertyNames).ToArray();

            // Assert
            difference.Should().BeEmpty();
        }
        
        [Test]
        public void InMemory_Nutrient_IsCompatibleWith_NutrientModel()
        {
            // Arrange
            var nutrientModelPropertyNames =
                typeof(NutrientModel).GetProperties(GetPropertyBindingFlags())
                    .Select(p => p.Name);
            var nutrientPropertyNames =
                typeof(Nutrient).GetProperties(GetPropertyBindingFlags())
                    .Select(p => p.Name);

            var difference = nutrientModelPropertyNames.Except(nutrientPropertyNames).ToArray();

            // Assert
            difference.Should().BeEmpty();
        }

        [Test]
        public void MongoDb_NutrientModel_IsCompatibleWith_Nutrient()
        {
            // Arrange
            var nutrientPropertyNames =
                typeof(Nutrient).GetProperties(GetPropertyBindingFlags())
                    .Select(p => p.Name);
            var nutrientModelPropertyNames =
                typeof(NutritionManager.DataStore.Mongo.Nutrients.NutrientModel).GetProperties(GetPropertyBindingFlags())
                    .Select(p => p.Name);

            var difference = nutrientPropertyNames.Except(nutrientModelPropertyNames).ToArray();

            // Assert
            difference.Should().BeEmpty();
        }
        
        [Test]
        public void MongoDb_Nutrient_IsCompatibleWith_NutrientModel()
        {
            // Arrange
            var nutrientModelPropertyNames =
                typeof(NutritionManager.DataStore.Mongo.Nutrients.NutrientModel).GetProperties(GetPropertyBindingFlags())
                    .Select(p => p.Name);
            var nutrientPropertyNames =
                typeof(Nutrient).GetProperties(GetPropertyBindingFlags())
                    .Select(p => p.Name);

            var difference = nutrientModelPropertyNames.Except(nutrientPropertyNames).ToArray();

            // Assert
            difference.Should().BeEmpty();
        }

        private static BindingFlags GetPropertyBindingFlags()
        {
            return BindingFlags.Instance
                   | BindingFlags.Public
                   | BindingFlags.DeclaredOnly;
        }
        
    }
}