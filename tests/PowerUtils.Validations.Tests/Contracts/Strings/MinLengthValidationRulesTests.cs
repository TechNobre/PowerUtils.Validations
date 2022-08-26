using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Tests.Fakes.Entities;
using PowerUtils.Validations.Tests.Fakes.Validations.Strings;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.Strings
{
    public class MinLengthValidationRulesTests
    {
        [Fact]
        public void NULLValue_Validate_Valid()
        {
            // Arrange
            var fake = new FakeEntity(null);
            var minLength = 10;


            // Act
            var act = new FakeMinLengthValidation(
                fake,
                minLength
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
            var minLength = 10;


            // Act
            var act = new FakeMinLengthValidation(
                fake,
                minLength
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


            // Act
            var act = new FakeMinLengthValidation(
                fake,
                minLength
            );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void ShortValue_Validate_Invalid()
        {
            // Arrange
            var fake = new FakeEntity("value");
            var minLength = 10;

            var expectedProperty = nameof(fake.FirstName);
            var expectedErrorCode = ErrorCodes.MIN + ":" + minLength;


            // Act
            var act = new FakeMinLengthValidation(
                fake,
                minLength
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
