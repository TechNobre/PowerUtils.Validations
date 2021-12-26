using FluentAssertions;
using PowerUtils.Validations.Contracts;
using System.Linq;
using Xunit;

namespace PowerUtils.Validations.Tests.Validations.Contracts.Numerics
{
    public class RangeValidationsContractTests
    {
        [Fact]
        public void Int_Valid()
        {
            // Arrange
            int value = 6;
            int min = 5;
            int max = 10;


            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .Range(min, max);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Int_Less()
        {
            // Arrange
            int value = 3;
            int min = 5;
            int max = 10;

            string expectedErrorCode = ErrorCodes.MIN + ":" + min;


            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .Range(min, max);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should().NotBeEmpty();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(expectedErrorCode);
        }

        [Fact]
        public void Int_Greater()
        {
            // Arrange
            int value = 60;
            int min = 5;
            int max = 10;

            string expectedErrorCode = ErrorCodes.MAX + ":" + max;


            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .Range(min, max);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should().NotBeEmpty();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(expectedErrorCode);
        }

        [Fact(DisplayName = "Int null valid")]
        public void IntNull_Null_Valid()
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

        [Fact(DisplayName = "Int less invalid")]
        public void IntNull_Less_Invalid()
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

            act.Notifications.Should()
                .NotBeEmpty();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(ErrorCodes.MIN + ":" + 2);
        }


        [Fact(DisplayName = "Int greater invalid")]
        public void IntNull_Greater_Invalid()
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

            act.Notifications.Should()
                .NotBeEmpty();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(ErrorCodes.MAX + ":" + 4);
        }
    }
}