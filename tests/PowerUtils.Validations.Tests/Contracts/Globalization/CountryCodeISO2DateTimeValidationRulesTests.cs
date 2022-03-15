using System.Linq;
using PowerUtils.Validations.Tests.Fakes.Validations.Globalization;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Contracts.Globalization;

public class CountryCodeISO2DateTimeValidationRulesTests
{
    [Fact]
    public void Value_NULL()
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
    public void Value_Empty()
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
    public void Value_Valid()
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
    public void Value_Invalid_ISO3()
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
    public void Value_Invalid_ISO2()
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
