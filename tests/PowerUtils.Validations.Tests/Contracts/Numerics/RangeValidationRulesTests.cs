using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Contracts;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.Numerics
{
    public class RangeValidationRulesTests
    {
        [Fact]
        public void InRange_ValidateInt_Valid()
        {
            // Arrange
            var value = 6;
            var min = 5;
            var max = 10;


            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .Range(min, max);


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
            var value = 3;
            var min = 5;
            var max = 10;


            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .Range(min, max);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(ErrorCodes.GetMinFormatted(min));
        }

        [Fact]
        public void Greater_ValidateInt_Invalid()
        {
            // Arrange
            var value = 60;
            var min = 5;
            var max = 10;


            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .Range(min, max);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(ErrorCodes.GetMaxFormatted(max));
        }

        [Fact]
        public void Null_ValidateIntNullable_Valid()
        {
            // Arrange
            int? value = null;


            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .Range(1, 4);


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
            int? value = 0;


            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .Range(2, 4);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(ErrorCodes.GetMinFormatted(2));
        }

        [Fact]
        public void Greater_ValidateIntNullable_Invalid()
        {
            // Arrange
            int? value = 40;


            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .Range(2, 4);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(ErrorCodes.GetMaxFormatted(4));
        }
    }
}
