using FluentAssertions;
using PowerUtils.Validations;
using PowerUtils.Validations.Tests.Fakes.Validations.Strings;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Strings
{
    public class OptionsStringValidationsContractTests
    {
        [Fact]
        public void Value_NULL()
        {
            // Arrange
            var fake = new FakeOptions(null);
            string[] options = new string[] { "op1", "Op2" };


            // Act
            var act = new FakeOptionsValidation(
                fake,
                options
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
            var fake = new FakeOptions(string.Empty);
            var options = new string[] { "op1", "Op2" };


            // Act
            var act = new FakeOptionsValidation(
                fake,
                options
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
            var fake = new FakeOptions("OP2");
            var options = new string[] { "OP2", "Op2" };


            // Act
            var act = new FakeOptionsValidation(
                fake,
                options
            );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Invalid()
        {
            // Arrange
            var fake = new FakeOptions("op3");
            var options = new string[] { "op1", "Op2" };

            string expectedProperty = nameof(fake.Value);
            string expectedErrorCode = ErrorCodes.INVALID;


            // Act
            var act = new FakeOptionsValidation(
                fake,
                options
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
        public void Value_Invalid_CustomPropertyName()
        {
            // Arrange
            var fake = new FakeOptions("op3");
            string[] options = new string[] { "op1", "Op2" };

            string expectedProperty = nameof(FakeOptionsPropertyNameValidation);
            string expectedErrorCode = ErrorCodes.INVALID;


            // Act
            var act = new FakeOptionsPropertyNameValidation(
                fake,
                options
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