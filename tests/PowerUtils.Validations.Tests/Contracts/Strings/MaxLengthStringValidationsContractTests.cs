using System.Linq;
using PowerUtils.Validations;
using PowerUtils.Validations.Tests.Fakes.Entities;
using PowerUtils.Validations.Tests.Fakes.Validations.Strings;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Strings;

public class MaxLengthStringValidationsContractTests
{
    [Fact]
    public void Value_NULL()
    {
        // Arrange
        var fake = new FakeEntity(null);
        var maxLength = 10;


        // Act
        var act = new FakeMaxLengthValidation(
            fake,
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
        var maxLength = 10;


        // Act
        var act = new FakeMaxLengthValidation(
            fake,
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
        var maxLength = 10;


        // Act
        var act = new FakeMaxLengthValidation(
            fake,
            maxLength
        );


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }


    [Fact]
    public void Value_Invalid()
    {
        // Arrange
        var fake = new FakeEntity("value");
        var maxLength = 4;

        var expectedProperty = nameof(fake.FirstName);
        var expectedErrorCode = ErrorCodes.MAX + ":" + maxLength;


        // Act
        var act = new FakeMaxLengthValidation(
            fake,
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
