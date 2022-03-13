using System.Linq;
using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.Entities;
using PowerUtils.Validations.Tests.Fakes.Validations.General;

namespace PowerUtils.Validations.Tests.Contracts.General;

public class GenderGeneralValidationsContractTests
{
    [Fact]
    public void Value_NULL()
    {
        // Arrange
        var fake = new FakeGender(null);


        // Act
        var act = new FakeGenderValidation(fake);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Value_Empty()
    {
        // Arrange
        var fake = new FakeGender(string.Empty);


        // Act
        var act = new FakeGenderValidation(fake);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Value_Valid_Male()
    {
        // Arrange
        var fake = new FakeGender("male");


        // Act
        var act = new FakeGenderValidation(fake);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Value_Valid_Female()
    {
        // Arrange
        var fake = new FakeGender("FemalE");


        // Act
        var act = new FakeGenderValidation(fake);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Value_Invalid()
    {
        // Arrange
        var fake = new FakeGender("op3");

        var expectedProperty = nameof(fake.Gender);
        var expectedErrorCode = ErrorCodes.INVALID;


        // Act
        var act = new FakeGenderValidation(fake);


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

    [Fact(DisplayName = "Test gender with support to other with value 'Other' - Should return TRUE")]
    public void GenderWithOther_Other_ReturnTrue()
    {
        // Arrange
        var gender = "Other";


        // Act
        var act = new ValidationsContract<string>(gender)
            .RuleFor("Gender")
            .GenderWithOther();


        // Assert
        act.Valid.Should()
            .BeTrue();
    }

    [Fact(DisplayName = "Test gender with support to other with value not 'Other'  - Should return FALSE")]
    public void Gender_NotOther_ReturnFalse()
    {
        // Arrange
        var gender = "Fake";


        // Act
        var act = new ValidationsContract<string>(gender)
            .RuleFor("Gender")
            .GenderWithOther();


        // Assert
        act.Invalid.Should()
            .BeTrue();
    }

    [Fact(DisplayName = "Test gender with support to other with value 'Male' - Should return TRUE")]
    public void GenderWithOther_Male_ReturnTrue()
    {
        // Arrange
        var gender = "male";


        // Act
        var act = new ValidationsContract<string>(gender)
            .RuleFor("Gender")
            .GenderWithOther();


        // Assert
        act.Valid.Should()
            .BeTrue();
    }
}
