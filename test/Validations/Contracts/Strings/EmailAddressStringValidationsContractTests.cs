using FluentAssertions;
using PowerUtils.RestAPI.Tests.Fakes.Validations.Strings;
using PowerUtils.RestAPI.Tests.Fakes.ValueObjects;
using PowerUtils.Validations;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Strings
{
    public class EmailAddressStringValidationsContractTests
    {
        [Fact]
        public void Value_NULL()
        {
            // Arrange
            FakeEmailAddress fake = new FakeEmailAddress(null);


            // Act
            var act = new FakeEmailAddressValidations(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Empty()
        {
            // Arrange
            FakeEmailAddress fake = new FakeEmailAddress(string.Empty);


            // Act
            var act = new FakeEmailAddressValidations(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Valid()
        {
            // Arrange
            FakeEmailAddress fake = new FakeEmailAddress("value@value.pt");


            // Act
            var act = new FakeEmailAddressValidations(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Invalid()
        {
            // Arrange
            FakeEmailAddress fake = new FakeEmailAddress("value@value.");

            string expectedProperty = nameof(fake.EmailAddress);
            string expectedErrorCode = ErrorCodes.INVALID;


            // Act
            var act = new FakeEmailAddressValidations(fake);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should().NotBeEmpty();

            act.Notifications.First().Property
                .Should()
                    .Be(expectedProperty);

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(expectedErrorCode);
        }
    }
}