using System;
using System.Collections.Generic;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using NutritionManager.DataStore.Mappings;

namespace NutritionManager.DataStore.Test.Mappings
{
    public class MappingAdapterTest
    {
        private MappingAdapter sut;
        
        [SetUp]
        public void Setup()
        {
            var mappings = new Dictionary<Type, Type>
            {
                { typeof(SourceType), typeof(DestinationType) }
            };
            
            this.sut = new MappingAdapter(mappings);   
        }

        [Test]
        public void Convert_ConvertsSourceTypeToDestinationType()
        {
            // Arrange
            var id = new Fixture().Create<int>();
            var name = new Fixture().Create<string>();
            var duration = new Fixture().Create<float>();

            var sourceObject = new SourceType(id, name, duration);

            // Act
            var destinationObject = this.sut.Convert<SourceType, DestinationType>(sourceObject);
            
            // Assert
            destinationObject.Should().NotBeNull();
            destinationObject.Id.Should().Be(sourceObject.Id);
            destinationObject.Name.Should().BeEquivalentTo(sourceObject.Name);
            destinationObject.Duration.Should().Be(sourceObject.Duration);
        }
        
        private class SourceType
        {
            public SourceType(int id, string name, float duration)
            {
                this.Id = id;
                this.Name = name;
                this.Duration = duration;
            }
            public int Id { get; }

            public string Name { get; }

            public float Duration { get; }
        }
        
        private class DestinationType
        {
            public DestinationType(int id, string name, float duration)
            {
                this.Id = id;
                this.Name = name;
                this.Duration = duration;
            }
            
            public int Id { get; }

            public string Name { get; }

            public float Duration { get; }
        }
    }
}