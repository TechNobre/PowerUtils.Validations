using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Contracts;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.PaginationValidations
{
    public class OrderingDirectionIgnoreCaseValidationRulesTests
    {
        [Fact]
        public void Null_ValidateOrderingDirection_NotValidate()
        {
            // Arrange
            string value = null;


            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("Fake")
                .OrderingDirectionIgnoreCase();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Empty_ValidateOrderingDirection_NotValidate()
        {
            // Arrange
            var value = string.Empty;


            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("Fake")
                .OrderingDirectionIgnoreCase();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void InvalidValue_ValidateOrderingDirection_NotValidate()
        {
            // Arrange
            var value = "fff";


            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("Fake")
                .OrderingDirectionIgnoreCase();


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(ErrorCodes.INVALID);
        }

        [Fact]
        public void Asc_ValidateOrderingDirection_Valid()
        {
            // Arrange
            var value = "asc";


            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("Fake")
                .OrderingDirectionIgnoreCase();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().
                BeEmpty();
        }

        [Fact]
        public void DeSc_ValidateOrderingDirection_Valid()
        {
            // Arrange
            var value = "DeSc";


            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("Fake")
                .OrderingDirectionIgnoreCase();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().
                BeEmpty();
        }
    }
}
