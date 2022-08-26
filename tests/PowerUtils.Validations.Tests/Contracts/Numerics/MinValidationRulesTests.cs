using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Contracts;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.Numerics
{
    public class MinValidationRulesTests
    {
        [Fact]
        public void Greater_ValidateInt_Valid()
        {
            // Arrange
            var value = 4;
            var min = 5;

            var expectedErrorCode = ErrorCodes.MIN + ":" + min;


            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .Min(min);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(expectedErrorCode);
        }

        [Fact]
        public void Equals_ValidateInt_Valid()
        {
            // Arrange
            var value = 6;
            var min = 6;

            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .Min(min);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Less_ValidateInt_Valid()
        {
            // Arrange
            var value = 8;
            var min = 7;

            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .Min(min);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Greater_ValidateIntNull_Invalid()
        {
            // Arrange
            int? value = 4;
            var min = 5;

            var expectedErrorCode = ErrorCodes.MIN + ":" + min;

            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .Min(min);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(expectedErrorCode);
        }

        [Fact]
        public void Null_ValidateIntNull_Valid()
        {
            // Arrange
            int? value = null;
            var min = 6;

            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .Min(min);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Equals_ValidateIntNull_Valid()
        {
            // Arrange
            int? value = 6;
            var min = 6;

            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .Min(min);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Less_ValidateIntNull_Valid()
        {
            // Arrange
            int? value = 8;
            var min = 7;

            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .Min(min);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }
    }
}
