using System.Linq;
using PowerUtils.Validations.Tests.Fakes.Validations.Strings;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Contracts.Strings;

public class EmailAddressStringValidationsContractTests
{
    [Fact]
    public void Value_NULL()
    {
        // Arrange
        var fake = new FakeEmailAddress(null);


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
        var fake = new FakeEmailAddress(string.Empty);


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
        var fake = new FakeEmailAddress("value@value.pt");


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
        var fake = new FakeEmailAddress("value@value.");

        var expectedProperty = nameof(fake.EmailAddress);
        var expectedErrorCode = ErrorCodes.INVALID;


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
