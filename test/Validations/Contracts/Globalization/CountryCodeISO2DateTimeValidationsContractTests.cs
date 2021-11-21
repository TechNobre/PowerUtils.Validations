using FluentAssertions;
using PowerUtils.RestAPI.Tests.Fakes.Validations.Globalization;
using PowerUtils.RestAPI.Tests.Fakes.ValueObjects;
using PowerUtils.Validations;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Globalization
{
    public class CountryCodeISO2DateTimeValidationsContractTests
    {
        [Fact]
        public void Value_NULL()
        {
            // Arrange
            FakeCountry fake = new FakeCountry(null);


            // Act
            var act = new FakeCountryValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Empty()
        {
            // Arrange
            FakeCountry fake = new FakeCountry(string.Empty);


            // Act
            var act = new FakeCountryValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Valid()
        {
            // Arrange
            FakeCountry fake = new FakeCountry("pt");


            // Act
            var act = new FakeCountryValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Invalid_ISO3()
        {
            // Arrange
            FakeCountry fake = new FakeCountry("PTR");

            string expectedProperty = nameof(fake.CountryCode);
            string expectedErrorCode = ErrorCodes.INVALID;


            // Act
            var act = new FakeCountryValidation(fake);


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

        [Fact]
        public void Value_Invalid_ISO2()
        {
            // Arrange
            FakeCountry fake = new FakeCountry("RR");

            string expectedProperty = nameof(fake.CountryCode);
            string expectedErrorCode = ErrorCodes.INVALID;


            // Act
            var act = new FakeCountryValidation(fake);


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