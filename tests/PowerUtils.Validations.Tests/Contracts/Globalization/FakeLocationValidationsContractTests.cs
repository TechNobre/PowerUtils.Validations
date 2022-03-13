using System.Linq;
using PowerUtils.Validations.Tests.Fakes.Validations.Globalization;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Validations.Contracts.Globalization;

public class FakeLocationValidationsContractTests
{
    [Fact]
    public void Invalid_Latitude_Min()
    {
        // Arrange
        var fake = new FakeLocation();
        fake.Latitude = -91.145;
        fake.Longitude = 14.145;

        var expectedProperty = nameof(fake.Latitude);
        var expectedErrorCode = ErrorCodes.MIN + ":" + -90;


        // Act
        var act = new FakeLocationValidation(fake);


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
    public void Invalid_Latitude_Max()
    {
        // Arrange
        var fake = new FakeLocation();
        fake.Latitude = 91.145;
        fake.Longitude = 14.145;

        var expectedProperty = nameof(fake.Latitude);
        var expectedErrorCode = ErrorCodes.MAX + ":" + 90;


        // Act
        var act = new FakeLocationValidation(fake);


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
    public void Invalid_Longitude_Min()
    {
        // Arrange
        var fake = new FakeLocation();
        fake.Latitude = -14.145;
        fake.Longitude = -184.145;

        var expectedProperty = nameof(fake.Longitude);
        var expectedErrorCode = ErrorCodes.MIN + ":" + -180;


        // Act
        var act = new FakeLocationValidation(fake);


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
    public void Invalid_Longitude_Max()
    {
        // Arrange
        var fake = new FakeLocation();
        fake.Latitude = -14.145;
        fake.Longitude = 184.145;

        var expectedProperty = nameof(fake.Longitude);
        var expectedErrorCode = ErrorCodes.MAX + ":" + 180;


        // Act
        var act = new FakeLocationValidation(fake);


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
    public void Valid_Location()
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

        act.Notifications.Should().BeEmpty();
    }
}
