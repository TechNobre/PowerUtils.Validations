using FluentAssertions;
using PowerUtils.RestAPI.Tests.Fakes.Validations.Objects;
using PowerUtils.RestAPI.Tests.Fakes.ValueObjects;
using PowerUtils.Validations;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Objects
{
    public class RequiredObjectValidationsContractTests
    {
        [Fact]
        public void Value_NULL()
        {
            // Arrange
            FakeCollection fake = new FakeCollection();
            fake.ValueList = null;

            string expectedProperty = nameof(fake.ValueList);
            string expectedErrorCode = ErrorCodes.REQUIRED;


            // Act
            var act = new FakeRequiredObjectValidation(fake);


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
        public void Value_NotNull()
        {
            // Arrange
            FakeCollection fake = new FakeCollection();
            fake.ValueList = new System.Collections.Generic.List<string>();


            // Act
            var act = new FakeRequiredObjectValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }
    }
}