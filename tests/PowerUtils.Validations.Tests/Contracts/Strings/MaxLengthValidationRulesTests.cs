using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Tests.Fakes.Entities;
using PowerUtils.Validations.Tests.Fakes.Validations.Strings;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.Strings
{
    public class MaxLengthValidationRulesTests
    {
        [Fact]
        public void NULLValue_Validate_Valid()
        {
            // Arrange
            var fake = new FakeEntity(null);
            var maxLength = 10;


            // Act
            var act = new FakeMaxLengthValidation(
                fake,
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
            var maxLength = 10;


            // Act
            var act = new FakeMaxLengthValidation(
                fake,
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
            var maxLength = 10;


            // Act
            var act = new FakeMaxLengthValidation(
                fake,
                maxLength
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
            var maxLength = 4;

            var expectedProperty = nameof(fake.FirstName);
            var expectedErrorCode = ErrorCodes.MAX + ":" + maxLength;


            // Act
            var act = new FakeMaxLengthValidation(
                fake,
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
