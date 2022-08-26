using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Contracts;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.Numerics
{
    public class MinZeroValidationRulesTests
    {
        [Fact]
        public void Greater_ValidateInt_Valid()
        {
            // Arrange
            var value = 4;


            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .MinZero();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Equals_ValidateInt_Valid()
        {
            // Arrange
            var value = 0;

            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .MinZero();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Less_ValidateInt_Invalid()
        {
            // Arrange
            var value = -8;


            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .MinZero();


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(ErrorCodes.GetMinFormatted(0));
        }

        [Fact]
        public void Null_ValidateIntNullable_Valid()
        {
            // Arrange
            int? value = null;

            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .MinZero();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Greater_ValidateIntNullable_Invalid()
        {
            // Arrange
            int? value = 4;

            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .MinZero();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Equals_ValidateIntNullable_Valid()
        {
            // Arrange
            int? value = 6;

            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .MinZero();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Less_ValidateIntNullable_Invalid()
        {
            // Arrange
            int? value = -8;

            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .MinZero();


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(ErrorCodes.GetMinFormatted(0));
        }
    }
}
