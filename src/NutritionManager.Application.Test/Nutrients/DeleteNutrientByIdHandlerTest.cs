﻿using System;
using System.Threading.Tasks;
using AutoFixture;
using FakeItEasy;
using NUnit.Framework;
using NutritionManager.Application.Common;
using NutritionManager.Application.Nutrients;
using NutritionManager.Application.Nutrients.Commands;
using NutritionManager.Application.Nutrients.Handlers;

namespace NutritionManager.Application.Test.Nutrients
{
    public class DeleteNutrientByIdHandlerTest
    {
        private IRepository<Nutrient, Guid> repository;

        private DeleteNutrientByIdHandler sut;

        [SetUp]
        public void Setup()
        {
            this.repository = A.Fake<IRepository<Nutrient, Guid>>();
            this.sut = new DeleteNutrientByIdHandler(this.repository);
        }

        [Test]
        public async Task HandleCommandAsync_WithValidParams_DeletesNutrient()
        {
            // Arrange
            var nutrientId = new Fixture().Create<Guid>();
            var command = new DeleteNutrientById(nutrientId);

            // Act
            await this.sut.HandleCommandAsync(command);

            // Assert
            A.CallTo(() => this.repository.RemoveOneByKeyAsync(nutrientId))
                .MustHaveHappenedOnceExactly();
        }

        private static Nutrient CreteFakeNutrient()
        {
            return Nutrient.Create(new Fixture().Create<string>());
        }
    }
}