using FluentAssertions;
using PowerUtils.Validations.Contracts;
using System.Linq;
using Xunit;

namespace PowerUtils.Validations.Tests.Validations.Contracts.Numerics
{
    public class MinValidationsContractTests
    {
        [Fact]
        public void Int_Greater()
        {
            // Arrange
            int value = 4;
            int min = 5;

            string expectedErrorCode = ErrorCodes.MIN + ":" + min;

            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .Min(min);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should().NotBeEmpty();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(expectedErrorCode);
        }

        [Fact]
        public void Int_Equals()
        {
            // Arrange
            int value = 6;
            int min = 6;

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
        public void Int_Less()
        {
            // Arrange
            int value = 8;
            int min = 7;

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
        public void IntNull_Greater_Invalid()
        {
            // Arrange
            int? value = 4;
            int min = 5;

            string expectedErrorCode = ErrorCodes.MIN + ":" + min;

            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .Min(min);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should()
                .NotBeEmpty();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(expectedErrorCode);
        }

        [Fact]
        public void IntNull_Null_Valid()
        {
            // Arrange
            int? value = null;
            int min = 6;

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
        public void IntNull_Equals_Valid()
        {
            // Arrange
            int? value = 6;
            int min = 6;

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
        public void IntNull_Less_Valid()
        {
            // Arrange
            int? value = 8;
            int min = 7;

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