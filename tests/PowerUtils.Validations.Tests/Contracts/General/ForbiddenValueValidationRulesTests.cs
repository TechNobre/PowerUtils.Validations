using System;
using System.Linq;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.Validations.Tests.Contracts.General;

public class ForbiddenValueValidationRulesTests
{
    [Fact]
    public void ForbiddenValue_Null_Valid()
    {
        // Arrange
        string value = null;

        var forbiddenValues = new string[] { "Value1", "VALUE2", "VaLUe3" };

        // Act
        var act = new ValidationsContract<string>(value)
            .RuleFor("Fake")
            .ForbiddenValue(forbiddenValues);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void ForbiddenValue_Empty_Valid()
    {
        // Arrange
        var value = string.Empty;

        var forbiddenValues = new string[] { "Value1", "VALUE2", "VaLUe3" };

        // Act
        var act = new ValidationsContract<string>(value)
            .RuleFor("Fake")
            .ForbiddenValue(forbiddenValues);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void ForbiddenValues_NullOptions_Valid()
    {
        // Arrange
        var value = "VALUE3";

        string[] forbiddenValues = null;

        // Act
        var act = new ValidationsContract<string>(value)
            .RuleFor("Fake")
            .ForbiddenValue(forbiddenValues);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void ForbiddenValue_EmptyOptions_Valid()
    {
        // Arrange
        var value = "VALUE3";

        var forbiddenValues = Array.Empty<string>();

        // Act
        var act = new ValidationsContract<string>(value)
            .RuleFor("Fake")
            .ForbiddenValue(forbiddenValues);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void ForbiddenValue_ValueOption_Valid()
    {
        // Arrange
        var value = "VALUE4";
        var forbiddenValues = new string[] { "Value1", "VALUE2", "VaLUe3" };


        // Act
        var act = new ValidationsContract<string>(value)
            .RuleFor("Fake")
            .ForbiddenValue(forbiddenValues);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void ForbiddenValue_OptionInList_Invalid()
    {
        // Arrange
        var value = "VALUE3";
        var forbiddenValues = new string[] { "Value1", "VALUE2", "VaLUe3" };


        // Act
        var act = new ValidationsContract<string>(value)
            .RuleFor("Fake")
            .ForbiddenValue(forbiddenValues);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().ErrorCode
           .Should()
               .Be(ErrorCodes.FORBIDDEN);
    }

    [Fact]
    public void ForbiddenValueInt_NullOptions_Valid()
    {
        // Arrange
        var value = 5;
        int[] forbiddenValues = null;


        // Act
        var act = new ValidationsContract<int>(value)
            .RuleFor("Fake")
            .ForbiddenValue(forbiddenValues);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void ForbiddenValueInt_EmptyOptions_Valid()
    {
        // Arrange
        var value = 5;
        var forbiddenValues = Array.Empty<int>();


        // Act
        var act = new ValidationsContract<int>(value)
            .RuleFor("Fake")
            .ForbiddenValue(forbiddenValues);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void ForbiddenValueInt_OutOptions_Valid()
    {
        // Arrange
        var value = 5;
        var forbiddenValues = new int[] { 568, 112, 9 };


        // Act
        var act = new ValidationsContract<int>(value)
            .RuleFor("Fake")
            .ForbiddenValue(forbiddenValues);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void ForbiddenValueInt_IntOptions_Valid()
    {
        // Arrange
        var value = 9;
        var forbiddenValues = new int[] { 568, 112, 9 };


        // Act
        var act = new ValidationsContract<int>(value)
            .RuleFor("Fake")
            .ForbiddenValue(forbiddenValues);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().ErrorCode
           .Should()
               .Be(ErrorCodes.FORBIDDEN);
    }

    [Fact]
    public void ForbiddenValueInt_Null_Valid()
    {
        // Arrange
        int? value = null;
        var forbiddenValues = new int?[] { 568, 112, 9 };


        // Act
        var act = new ValidationsContract<int?>(value)
            .RuleFor("Fake")
            .ForbiddenValue(forbiddenValues);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }
}
