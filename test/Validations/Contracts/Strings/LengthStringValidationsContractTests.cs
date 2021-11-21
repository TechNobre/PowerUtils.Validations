﻿using FluentAssertions;
using PowerUtils.RestAPI.Tests.Fakes.Entities;
using PowerUtils.RestAPI.Tests.Fakes.Validations.Strings;
using PowerUtils.Validations;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Strings
{
    public class LengthStringValidationsContractTests
    {
        [Fact]
        public void Value_NULL()
        {
            // Arrange
            FakeEntity fake = new FakeEntity(null);
            int minLength = 3;
            int maxLength = 10;


            // Act
            var act = new FakeLengthValidation(
                fake,
                minLength,
                maxLength
            );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Empty()
        {
            // Arrange
            FakeEntity fake = new FakeEntity(string.Empty);
            int minLength = 3;
            int maxLength = 10;


            // Act
            var act = new FakeLengthValidation(
                fake,
                minLength,
                maxLength
            );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Valid()
        {
            // Arrange
            FakeEntity fake = new FakeEntity("value");
            int minLength = 3;
            int maxLength = 10;


            // Act
            var act = new FakeLengthValidation(
                fake,
                minLength,
                maxLength
            );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Invalid_Max()
        {
            // Arrange
            FakeEntity fake = new FakeEntity("value 1234");
            int minLength = 3;
            int maxLength = 6;

            string expectedProperty = nameof(fake.FirstName);
            string expectedErrorCode = ErrorCodes.MAX + ":" + maxLength;


            // Act
            var act = new FakeLengthValidation(
                fake,
                minLength,
                maxLength
            );


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should().NotBeEmpty();

            act.Notifications.First().Property
                .Should()
                    .Be(expectedProperty);

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(expectedErrorCode);
        }

        [Fact]
        public void Value_Invalid_Min()
        {
            // Arrange
            FakeEntity fake = new FakeEntity("val");
            int minLength = 4;
            int maxLength = 10;

            string expectedProperty = nameof(fake.FirstName);
            string expectedErrorCode = ErrorCodes.MIN + ":" + minLength;


            // Act
            var act = new FakeLengthValidation(
                fake,
                minLength,
                maxLength
            );


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should().NotBeEmpty();

            act.Notifications.First().Property
                .Should()
                    .Be(expectedProperty);

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(expectedErrorCode);
        }
    }
}