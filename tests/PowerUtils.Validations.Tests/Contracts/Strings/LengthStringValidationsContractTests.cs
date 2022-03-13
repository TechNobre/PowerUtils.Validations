using System.Linq;
using PowerUtils.Validations;
using PowerUtils.Validations.Tests.Fakes.Entities;
using PowerUtils.Validations.Tests.Fakes.Validations.Strings;

namespace PowerUtils.Validations.Tests.Contracts.Strings;

public class LengthStringValidationsContractTests
{
    [Fact]
    public void Value_NULL()
    {
        // Arrange
        var fake = new FakeEntity(null);
        var minLength = 3;
        var maxLength = 10;


        // Act
        var act = new FakeLengthValidation(
            fake,
            minLength,
            maxLength
        );


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Value_Empty()
    {
        // Arrange
        var fake = new FakeEntity(string.Empty);
        var minLength = 3;
        var maxLength = 10;


        // Act
        var act = new FakeLengthValidation(
            fake,
            minLength,
            maxLength
        );


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Value_Valid()
    {
        // Arrange
        var fake = new FakeEntity("value");
        var minLength = 3;
        var maxLength = 10;


        // Act
        var act = new FakeLengthValidation(
            fake,
            minLength,
            maxLength
        );


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Value_Invalid_Max()
    {
        // Arrange
        var fake = new FakeEntity("value 1234");
        var minLength = 3;
        var maxLength = 6;

        var expectedProperty = nameof(fake.FirstName);
        var expectedErrorCode = ErrorCodes.MAX + ":" + maxLength;


        // Act
        var act = new FakeLengthValidation(
            fake,
            minLength,
            maxLength
        );


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
    public void Value_Invalid_Min()
    {
        // Arrange
        var fake = new FakeEntity("val");
        var minLength = 4;
        var maxLength = 10;

        var expectedProperty = nameof(fake.FirstName);
        var expectedErrorCode = ErrorCodes.MIN + ":" + minLength;


        // Act
        var act = new FakeLengthValidation(
            fake,
            minLength,
            maxLength
        );


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
