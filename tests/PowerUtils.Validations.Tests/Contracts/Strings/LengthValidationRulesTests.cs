using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Tests.Fakes.Entities;
using PowerUtils.Validations.Tests.Fakes.Validations.Strings;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.Strings
{
    public class LengthValidationRulesTests
    {
        [Fact]
        public void NULLValue_Validate_Valid()
        {
            // Arrange
            var fake = new FakeEntity(null);
            var minLength = 3;
            var maxLength = 10;


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
        public void EmptyValue_Validate_Valid()
        {
            // Arrange
            var fake = new FakeEntity(string.Empty);
            var minLength = 3;
            var maxLength = 10;


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
        public void Value_Validate_Valid()
        {
            // Arrange
            var fake = new FakeEntity("value");
            var minLength = 3;
            var maxLength = 10;


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
        public void LongValue_ValidateLength_Invalid()
        {
            // Arrange
            var fake = new FakeEntity("value 1234");
            var minLength = 3;
            var maxLength = 6;

            var expectedProperty = nameof(fake.FirstName);
            var expectedErrorCode = ErrorCodes.MAX + ":" + maxLength;


            // Act
            var act = new FakeLengthValidation(
                fake,
                minLength,
                maxLength
            );


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
        public void ShortValue_ValidateLength_Invalid()
        {
            // Arrange
            var fake = new FakeEntity("val");
            var minLength = 4;
            var maxLength = 10;

            var expectedProperty = nameof(fake.FirstName);
            var expectedErrorCode = ErrorCodes.MIN + ":" + minLength;


            // Act
            var act = new FakeLengthValidation(
                fake,
                minLength,
                maxLength
            );


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
