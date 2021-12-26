using FluentAssertions;
using PowerUtils.Validations.Contracts;
using System.Linq;
using Xunit;

namespace PowerUtils.Validations.Tests.Validations.Contracts.Numerics
{
    public class MinZeroValidationsContractTests
    {
        [Fact(DisplayName = "Greater than min allowed - Success")]
        [Trait("Category", "Min Validation")]
        public void Int_Greater()
        {
            // Arrange
            int value = 4;


            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .MinZero();


            // Assert
            act.Valid
                .Should()
                    .BeTrue();

            act.Notifications
                .Should()
                    .BeEmpty();
        }

        [Fact(DisplayName = "Equals than min allowed - Success")]
        [Trait("Category", "Min Validation")]
        public void Int_Equals()
        {
            // Arrange
            int value = 0;

            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .MinZero();


            // Assert
            act.Valid
                .Should()
                    .BeTrue();

            act.Notifications
                .Should()
                    .BeEmpty();
        }

        [Fact(DisplayName = "Less than min allowed - Error")]
        [Trait("Category", "Min Validation")]
        public void Int_Less()
        {
            // Arrange
            int value = -8;


            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .MinZero();


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications
                .Should()
                    .NotBeEmpty();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(ErrorCodes.GetMinFormatted(0));
        }

        [Fact(DisplayName = "Greater than min allowed (Nullable) - Error")]
        [Trait("Category", "Min Validation")]
        public void IntNull_Greater_Invalid()
        {
            // Arrange
            int? value = 4;

            // Act
            var act = new ValidationsContract<int?>(value)
                .RuleFor("Fake")
                .MinZero();


            // Assert
            act.Valid
                .Should()
                    .BeTrue();

            act.Notifications
                .Should()
                    .BeEmpty();
        }

        [Fact(DisplayName = "Nulvalue (Nullable) - Success")]
        [Trait("Category", "Min Validation")]
        public void IntNull_Null_Valid()
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

        [Fact(DisplayName = "Equals than min allowed (Nullable) - Error")]
        [Trait("Category", "Min Validation")]
        public void IntNull_Equals_Valid()
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

        [Fact(DisplayName = "Less than min allowed (Nullable) - Error")]
        [Trait("Category", "Min Validation")]
        public void IntNull_Less_Valid()
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

            act.Notifications
                .Should()
                    .NotBeEmpty();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(ErrorCodes.GetMinFormatted(0));
        }
    }
}