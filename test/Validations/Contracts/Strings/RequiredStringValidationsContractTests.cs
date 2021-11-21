using FluentAssertions;
using PowerUtils.RestAPI.Tests.Fakes.Entities;
using PowerUtils.RestAPI.Tests.Fakes.Validations.Strings;
using PowerUtils.Validations;
using PowerUtils.Validations.Contracts;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Strings
{
    public class RequiredStringValidationsContractTests
    {
        [Fact]
        public void Value_NULL()
        {
            // Arrange
            FakeEntity fake = new FakeEntity(null);
            string expectedProperty = nameof(fake.FirstName);
            string expectedErrorCode = ErrorCodes.REQUIRED;


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
        public void Value_Empty()
        {
            // Arrange
            FakeEntity fake = new FakeEntity(string.Empty);
            string expectedProperty = nameof(fake.FirstName);
            string expectedErrorCode = ErrorCodes.REQUIRED;


            // Act
            var act = new FakeRequiredValidation(fake);


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
        public void Value_WhiteSpace()
        {
            // Arrange
            FakeEntity fake = new FakeEntity(" ");


            // Act
            var act = new FakeRequiredValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void DirectValidation_Null()
        {
            // Arrange
            string value = null;

            string expectedProperty = "FirstName";
            string expectedErrorCode = ErrorCodes.REQUIRED;


            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("FirstName")
                .Required()
                .Length(4, 5);


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
        public void DirectValidation_Empty()
        {
            // Arrange
            string value = string.Empty;

            string expectedProperty = "FirstName";
            string expectedErrorCode = ErrorCodes.REQUIRED;


            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("FirstName")
                .Required()
                .Length(4, 5);


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
        public void DirectValidation_WithValue()
        {
            // Arrange
            string value = "Test";

            string expectedProperty = "FirstName";
            string expectedErrorCode = ErrorCodes.MIN + ":" + 8;


            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("FirstName")
                .Required()
                .Length(8, 15);


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