using FluentAssertions;
using PowerUtils.Validations.Contracts;
using System.Linq;
using Xunit;

namespace PowerUtils.Validations.Tests.Validations.Contracts.General
{
    public class ForbiddenValueValidationsContractTests
    {
        [Fact]
        public void String_Value_Null()
        {
            // Arrange
            string value = null;

            var forbiddenValues = new string[] { "Value1", "VALUE2", "VaLUe3" };

            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("Fake")
                .ForbiddenValue(forbiddenValues);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void String_Value_Empty()
        {
            // Arrange
            string value = string.Empty;

            var forbiddenValues = new string[] { "Value1", "VALUE2", "VaLUe3" };

            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("Fake")
                .ForbiddenValue(forbiddenValues);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void String_ForbiddenValues_Null()
        {
            // Arrange
            string value = "VALUE3";

            string[] forbiddenValues = null;

            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("Fake")
                .ForbiddenValue(forbiddenValues);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void String_ForbiddenValues_Empty()
        {
            // Arrange
            string value = "VALUE3";

            var forbiddenValues = new string[0];

            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("Fake")
                .ForbiddenValue(forbiddenValues);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void String_Value_Valid()
        {
            // Arrange
            string value = "VALUE4";

            var forbiddenValues = new string[] { "Value1", "VALUE2", "VaLUe3" };

            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("Fake")
                .ForbiddenValue(forbiddenValues);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void String_Value_Forbidden()
        {
            // Arrange
            string value = "VALUE3";

            var forbiddenValues = new string[] { "Value1", "VALUE2", "VaLUe3" };

            string expectedErrorCode = ErrorCodes.FORBIDDEN;

            // Act
            var act = new ValidationsContract<string>(value)
                .RuleFor("Fake")
                .ForbiddenValue(forbiddenValues);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should().NotBeEmpty();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(expectedErrorCode);
        }

        [Fact]
        public void Int_ForbiddenValues_Null()
        {
            // Arrange
            int value = 5;

            int[] forbiddenValues = null;

            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .ForbiddenValue(forbiddenValues);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Int_ForbiddenValues_Empty()
        {
            // Arrange
            int value = 5;

            var forbiddenValues = new int[0];

            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .ForbiddenValue(forbiddenValues);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Int_Value_Valid()
        {
            // Arrange
            int value = 5;

            var forbiddenValues = new int[] { 568, 112, 9 };

            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .ForbiddenValue(forbiddenValues);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Int_Value_Forbidden()
        {
            // Arrange
            int value = 9;

            var forbiddenValues = new int[] { 568, 112, 9 };

            string expectedErrorCode = ErrorCodes.FORBIDDEN;

            // Act
            var act = new ValidationsContract<int>(value)
                .RuleFor("Fake")
                .ForbiddenValue(forbiddenValues);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should().NotBeEmpty();

            act.Notifications.First().ErrorCode
               .Should()
                   .Be(expectedErrorCode);
        }
    }
}