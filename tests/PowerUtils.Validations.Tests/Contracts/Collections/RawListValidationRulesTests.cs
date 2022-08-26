using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Tests.Fakes.Validations.Objects;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.Collections
{
    public class RawListValidationRulesTests
    {
        [Fact]
        public void Null_ValidateContract_Invalid()
        {
            // Arrange
            List<string> fake = null;

            var expectedProperty = "FakeProperty";
            var expectedErrorCode = ErrorCodes.REQUIRED;


            // Act
            var act = new FakeRawListValidation(fake);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(expectedProperty);

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(expectedErrorCode);
        }


        [Fact]
        public void NotNull_ValidateContract_Valid()
        {
            // Arrange
            var fake = new List<string> { "fake1", "fake2" };


            // Act
            var act = new FakeRawListValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }
    }
}
