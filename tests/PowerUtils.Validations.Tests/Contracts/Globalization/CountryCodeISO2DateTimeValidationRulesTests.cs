using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Tests.Fakes.Validations.Globalization;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.Globalization
{
    public class CountryCodeISO2DateTimeValidationRulesTests
    {
        [Fact]
        public void NULL_Validate_Valid()
        {
            // Arrange
            var fake = new FakeCountry(null);


            // Act
            var act = new FakeCountryValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Empty_Validate_Valid()
        {
            // Arrange
            var fake = new FakeCountry(string.Empty);


            // Act
            var act = new FakeCountryValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Validate_Valid()
        {
            // Arrange
            var fake = new FakeCountry("pt");


            // Act
            var act = new FakeCountryValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void ISO3_Validate_Invalid()
        {
            // Arrange
            var fake = new FakeCountry("PTR");

            var expectedProperty = nameof(fake.CountryCode);
            var expectedErrorCode = ErrorCodes.INVALID;


            // Act
            var act = new FakeCountryValidation(fake);


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
        public void InvalidISO2_Validate_Valid()
        {
            // Arrange
            var fake = new FakeCountry("RR");

            var expectedProperty = nameof(fake.CountryCode);
            var expectedErrorCode = ErrorCodes.INVALID;


            // Act
            var act = new FakeCountryValidation(fake);


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
