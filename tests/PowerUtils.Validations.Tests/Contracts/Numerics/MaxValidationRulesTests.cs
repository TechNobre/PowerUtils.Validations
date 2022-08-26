using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Contracts;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.Numerics
{
    public class MaxValidationRulesTests
    {
        [Fact]
        public void Less_ValidateInt_Valid()
        {
            // Arrange
            var value = 4;
            var max = 5;


            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .Max(max);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Equals_ValidateInt_Valid()
        {
            // Arrange
            var value = 6;
            var max = 6;


            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .Max(max);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Greater_ValidateInt_Valid()
        {
            // Arrange
            var value = 8;
            var max = 7;

            var expectedErrorCode = ErrorCodes.MAX + ":" + max;

            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .Max(max);


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


            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .Max(5);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().
                BeEmpty();
        }

        [Fact]
        public void Less_ValidateIntNull_Valid()
        {
            // Arrange
            int? value = 4;


            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .Max(5);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().
                BeEmpty();
        }

        [Fact]
        public void Equals_ValidateIntNull_Valid()
        {
            // Arrange
            int? value = 6;


            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .Max(6);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Greater_ValidateIntNull_Invalid()
        {
            // Arrange
            int? value = 8;
            var max = 7;


            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .Max(max);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(ErrorCodes.MAX + ":" + max);
        }
    }
}
