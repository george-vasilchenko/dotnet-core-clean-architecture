﻿using System;
using System.Linq.Expressions;
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
    public class CreateNutrientHandlerTest
    {
        private IRepository<Nutrient, Guid> repository;

        private CreateNutrientHandler sut;

        [SetUp]
        public void Setup()
        {
            this.repository = A.Fake<IRepository<Nutrient, Guid>>();
            this.sut = new CreateNutrientHandler(this.repository);
        }

        [Test]
        public async Task HandleCommandAsync_WithValidArgs_CreatesAndSavesNutrient()
        {
            // Arrange
            var nutrientTitle = new Fixture().Create<string>();
            var command = new CreateNutrient(nutrientTitle);

            // Act
            await this.sut.HandleCommandAsync(command);

            // Assert
            A.CallTo(() => this.repository
                    .InsertOneAsync(A<Nutrient>.That.Matches(n => n.Title == command.Title)))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public void HandleCommandAsync_WithNullCommand_Throws()
        {
            // Arrange
            const CreateNutrient command = default;

            // Act
            Func<Task> run = async () => await this.sut.HandleCommandAsync(command!);

            // Assert
            run.Should().ThrowExactly<ArgumentNullException>()
                .Where(e => e.Message.Contains(nameof(command)));
        }

        [Test]
        public void HandleCommandAsync_WithExistingNutrient_Throws()
        {
            // Arrange
            var nutrientTitle = new Fixture().Create<string>();
            var fakeNutrient = Nutrient.Create(nutrientTitle);
            var command = new CreateNutrient(nutrientTitle);

            A.CallTo(() => this.repository.FindOneAsync(A<Expression<Func<Nutrient, bool>>>.Ignored))
                .Returns(fakeNutrient);

            // Act
            Func<Task> run = async () => await this.sut.HandleCommandAsync(command);

            // Assert
            run.Should().ThrowExactly<InvalidOperationException>()
                .WithMessage($"Nutrient with the title {nutrientTitle} already exists");
            A.CallTo(() => this.repository.FindOneAsync(A<Expression<Func<Nutrient, bool>>>.Ignored))
                .MustHaveHappenedOnceExactly();
        }
    }
}