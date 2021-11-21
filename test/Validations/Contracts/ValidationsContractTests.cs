using FluentAssertions;
using PowerUtils.Validations;
using PowerUtils.Validations.Tests.Fakes.Entities;
using PowerUtils.Validations.Tests.Fakes.Validations;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts
{
    public class ValidationsContractTests
    {
        [Fact]
        public void MultiErrors_SameProperty()
        {
            // Arrange
            var fake = new FakeEntity(null, null);
            string expectedProperty = nameof(fake.FirstName);
            string expectedErrorCode = ErrorCodes.REQUIRED;


            // Act
            var act = new FakeMultiValidations(fake);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Count.Should()
                .Be(1);

            act.Notifications.First().Property
                .Should()
                    .Be(expectedProperty);

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(expectedErrorCode);
        }
    }
}