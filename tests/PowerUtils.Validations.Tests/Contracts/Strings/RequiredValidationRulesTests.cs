﻿using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.Entities;
using PowerUtils.Validations.Tests.Fakes.Validations.Strings;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.Strings
{
    public class RequiredValidationRulesTests
    {
        [Fact]
        public void NULLValue_Validate_Invalid()
        {
            // Arrange
            var fake = new FakeEntity(null);
            var expectedProperty = nameof(fake.FirstName);
            var expectedErrorCode = ErrorCodes.REQUIRED;


            // Act
            var act = new FakeRequiredValidation(fake);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(expectedProperty);

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(expectedErrorCode);
        }

        [Fact]
        public void EmptyValue_Validate_Invalid()
        {
            // Arrange
            var fake = new FakeEntity(string.Empty);
            var expectedProperty = nameof(fake.FirstName);
            var expectedErrorCode = ErrorCodes.REQUIRED;


            // Act
            var act = new FakeRequiredValidation(fake);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(expectedProperty);

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(expectedErrorCode);
        }

        [Fact]
        public void WhiteSpace_Validate_Valid()
        {
            // Arrange
            var fake = new FakeEntity(" ");


            // Act
            var act = new FakeRequiredValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void NullDirectValidation_Validate_Invalid()
        {
            // Arrange
            string value = null;

            var expectedProperty = "FirstName";
            var expectedErrorCode = ErrorCodes.REQUIRED;


            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("FirstName")
                .Required()
                .Length(4, 5);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(expectedProperty);

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(expectedErrorCode);
        }

        [Fact]
        public void EmptyDirectValidation_Validate_Invalid()
        {
            // Arrange
            var value = string.Empty;

            var expectedProperty = "FirstName";
            var expectedErrorCode = ErrorCodes.REQUIRED;


            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("FirstName")
                .Required()
                .Length(4, 5);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(expectedProperty);

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(expectedErrorCode);
        }

        [Fact]
        public void WithValue_ValidateDirectValidation_Invalid()
        {
            // Arrange
            var value = "Test";

            var expectedProperty = "FirstName";
            var expectedErrorCode = ErrorCodes.MIN + ":" + 8;


            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("FirstName")
                .Required()
                .Length(8, 15);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(expectedProperty);

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(expectedErrorCode);
        }
    }
}
