using System.Linq;
using PowerUtils.Validations.Tests.Fakes.Validations.Strings;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Contracts.Strings;

public class EmailAddressValidationRulesTests
{
    [Fact]
    public void Email_NULL_Valid()
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
    public void Email_Empty_Valid()
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
    public void Email_ValidEmail_Valid()
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
    public void Email_InvalidEmail_Invalid()
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
