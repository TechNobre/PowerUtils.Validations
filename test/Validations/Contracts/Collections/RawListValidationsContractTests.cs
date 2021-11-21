using FluentAssertions;
using PowerUtils.RestAPI.Tests.Fakes.Validations.Objects;
using PowerUtils.Validations;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Collections
{
    public class RawListValidationsContractTests
    {
        [Fact]
        public void Value_Null()
        {
            // Arrange
            List<string> fake = null;

            string expectedProperty = "FakeProperty";
            string expectedErrorCode = ErrorCodes.REQUIRED;


            // Act
            var act = new FakeRawListValidation(
                 fake
            );


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should()
                .NotBeEmpty();

            act.Notifications.First().Property
                .Should()
                    .Be(expectedProperty);

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(expectedErrorCode);
        }


        [Fact]
        public void Value_NotNull()
        {
            // Arrange
            List<string> fake = new List<string> { "fake1", "fake2" };


            // Act
            var act = new FakeRawListValidation(
                 fake
            );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }
    }
}