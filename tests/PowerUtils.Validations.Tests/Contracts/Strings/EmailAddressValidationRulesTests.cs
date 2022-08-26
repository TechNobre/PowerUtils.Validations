using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Tests.Fakes.Validations.Strings;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.Strings
{
    public class EmailAddressValidationRulesTests
    {
        [Fact]
        public void NULL_ValidateEmail_Valid()
        {
            // Arrange
            var fake = new FakeEmailAddress(null);


            // Act
            var act = new FakeEmailAddressValidations(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Empty_ValidateEmail_Valid()
        {
            // Arrange
            var fake = new FakeEmailAddress(string.Empty);


            // Act
            var act = new FakeEmailAddressValidations(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void ValidEmail_ValidateEmail_Valid()
        {
            // Arrange
            var fake = new FakeEmailAddress("value@value.pt");


            // Act
            var act = new FakeEmailAddressValidations(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void InvalidEmail_ValidateEmail_Invalid()
        {
            // Arrange
            var fake = new FakeEmailAddress("value@value.");


            // Act
            var act = new FakeEmailAddressValidations(fake);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(nameof(fake.EmailAddress));

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.INVALID);
        }
    }
}
