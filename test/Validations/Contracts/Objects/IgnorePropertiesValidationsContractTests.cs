using FluentAssertions;
using PowerUtils.RestAPI.Tests.Fakes.Validations.Objects;
using PowerUtils.RestAPI.Tests.Fakes.ValueObjects;
using PowerUtils.Validations;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Objects
{
    public class IgnorePropertiesValidationsContractTests
    {
        [Fact]
        public void IgnoreProperty_WithRules()
        {
            // Arrange
            FakeCollection fake = new FakeCollection();
            fake.ValueList = null;


            // Act
            var act = new FakeRequiredObjectValidation(fake, "ValueList");


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }


        [Fact]
        public void IgnoreProperty_NullRules()
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
    }
}