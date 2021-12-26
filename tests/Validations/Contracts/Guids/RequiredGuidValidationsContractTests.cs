using FluentAssertions;
using PowerUtils.Validations;
using PowerUtils.Validations.Tests.Fakes.Validations.Guids;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;
using System;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Guids
{
    public class RequiredGuidValidationsContractTests
    {
        [Fact]
        public void Value_Valid()
        {
            // Arrange
            FakeId fake = new FakeId(Guid.NewGuid());


            // Act
            var act = new FakeIdValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Empty()
        {
            // Arrange
            var fake = new FakeId(Guid.Empty);
            var expectedProperty = nameof(fake.Id);
            var expectedErrorCode = ErrorCodes.REQUIRED;


            // Act
            var act = new FakeIdValidation(fake);


            // Assert
            act.Valid.Should()
                .BeFalse();

            act.Notifications.First().Property
                .Should()
                    .Be(expectedProperty);

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(expectedErrorCode);
        }
    }
}