using System.Linq;
using PowerUtils.Validations.Tests.Fakes.Validations.Globalization;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Contracts.Globalization;

public class LocationValidationRulesTests
{
    [Fact]
    public void Latitude_BelowMin_Invalid_()
    {
        // Arrange
        var fake = new FakeLocation();
        fake.Latitude = -91.145;
        fake.Longitude = 14.145;


        // Act
        var act = new FakeLocationValidation(fake);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().Property
            .Should()
                .Be(nameof(fake.Latitude));

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.GetMinFormatted(-90));
    }

    [Fact]
    public void Latitude_AboveMax_Invalid()
    {
        // Arrange
        var fake = new FakeLocation();
        fake.Latitude = 91.145;
        fake.Longitude = 14.145;


        // Act
        var act = new FakeLocationValidation(fake);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().Property
            .Should()
                .Be(nameof(fake.Latitude));

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.GetMaxFormatted(90));
    }

    [Fact]
    public void Longitude_BelowMin_Invalid()
    {
        // Arrange
        var fake = new FakeLocation();
        fake.Latitude = -14.145;
        fake.Longitude = -184.145;



        // Act
        var act = new FakeLocationValidation(fake);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().Property
            .Should()
                .Be(nameof(fake.Longitude));

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.GetMinFormatted(-180));
    }

    [Fact]
    public void Longitude_AboveMax_Invalid()
    {
        // Arrange
        var fake = new FakeLocation();
        fake.Latitude = -14.145;
        fake.Longitude = 184.145;


        // Act
        var act = new FakeLocationValidation(fake);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().Property
            .Should()
                .Be(nameof(fake.Longitude));

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.GetMaxFormatted(180));
    }

    [Fact]
    public void Location_Validcoordenates_Valid()
    {
        // Arrange
        var fake = new FakeLocation();
        fake.Latitude = -14.145;
        fake.Longitude = 14.145;


        // Act
        var act = new FakeLocationValidation(fake);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }
}
