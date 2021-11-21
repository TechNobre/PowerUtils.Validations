using FluentAssertions;
using PowerUtils.RestAPI.Tests.Fakes.Validations.Guids;
using PowerUtils.RestAPI.Tests.Fakes.ValueObjects;
using PowerUtils.Validations;
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
            FakeId fake = new FakeId(Guid.Empty);
            string expectedProperty = nameof(fake.Id);
            string expectedErrorCode = ErrorCodes.REQUIRED;


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