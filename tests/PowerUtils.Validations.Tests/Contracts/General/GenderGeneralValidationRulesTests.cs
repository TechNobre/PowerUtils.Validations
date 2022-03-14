using System.Linq;
using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.Entities;
using PowerUtils.Validations.Tests.Fakes.Validations.General;

namespace PowerUtils.Validations.Tests.Contracts.General;

public class GenderGeneralValidationRulesTests
{
    [Fact]
    public void Gender_NULL_Valid()
    {
        // Arrange
        var fake = new FakeGender(null);


        // Act
        var act = new FakeGenderValidation(fake);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void Gender_Empty_Valid()
    {
        // Arrange
        var fake = new FakeGender("");


        // Act
        var act = new FakeGenderValidation(fake);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void Gender_Male_Valid()
    {
        // Arrange
        var fake = new FakeGender("male");


        // Act
        var act = new FakeGenderValidation(fake);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void Gender_Female_Valid()
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
    public void Gender_InvalidValue_Invalid()
    {
        // Arrange
        var fake = new FakeGender("op3");


        // Act
        var act = new FakeGenderValidation(fake);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().Property
            .Should()
                .Be(nameof(fake.Gender));

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.INVALID);
    }

    [Fact]
    public void GenderWithOther_Other_Valid()
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

    [Fact]
    public void Gender_NotOther_Invalid()
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

        act.Notifications.First().Property
            .Should()
                .Be("Gender");

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.INVALID);
    }

    [Fact]
    public void GenderWithOther_Male_Valid()
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

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void GenderWithOther_Null_Valid()
    {
        // Arrange
        string gender = null;


        // Act
        var act = new ValidationsContract<string>(gender)
            .RuleFor("Gender")
            .GenderWithOther();


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void GenderWithOther_Empty_Valid()
    {
        // Arrange
        var gender = "";


        // Act
        var act = new ValidationsContract<string>(gender)
            .RuleFor("Gender")
            .GenderWithOther();


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }
}
