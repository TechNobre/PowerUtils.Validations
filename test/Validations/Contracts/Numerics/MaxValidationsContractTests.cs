using FluentAssertions;
using PowerUtils.Validations;
using PowerUtils.Validations.Contracts;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Numerics
{
    public class MaxValidationsContractTests
    {
        [Fact]
        public void Int_Less()
        {
            // Arrange
            int value = 4;
            int max = 5;


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
        public void Int_Equals()
        {
            // Arrange
            int value = 6;
            int max = 6;


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
        public void Int_Greater()
        {
            // Arrange
            int value = 8;
            int max = 7;

            string expectedErrorCode = ErrorCodes.MAX + ":" + max;

            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .Max(max);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should().NotBeEmpty();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(expectedErrorCode);
        }

        [Fact]
        public void IntNull_Null_Valid()
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
        public void IntNull_Less_Valid()
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
        public void IntNull_Equals_Valid()
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
        public void IntNull_Greater_Invalid()
        {
            // Arrange
            int? value = 8;
            int max = 7;


            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .Max(max);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should()
                .NotBeEmpty();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(ErrorCodes.MAX + ":" + max);
        }
    }
}