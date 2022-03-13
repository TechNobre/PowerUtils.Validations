using System;
using System.Linq;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.Validations.Tests.Contracts.General;

public class ForbiddenValueValidationsContractTests
{
    [Fact]
    public void String_Value_Null()
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

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void String_Value_Empty()
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

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void String_ForbiddenValues_Null()
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

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void String_ForbiddenValues_Empty()
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

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void String_Value_Valid()
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

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void String_Value_Forbidden()
    {
        // Arrange
        var value = "VALUE3";

        var forbiddenValues = new string[] { "Value1", "VALUE2", "VaLUe3" };

        var expectedErrorCode = ErrorCodes.FORBIDDEN;

        // Act
        var act = new ValidationsContract<string>(value)
            .RuleFor("Fake")
            .ForbiddenValue(forbiddenValues);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should().NotBeEmpty();

        act.Notifications.First().ErrorCode
           .Should()
               .Be(expectedErrorCode);
    }

    [Fact]
    public void Int_ForbiddenValues_Null()
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

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Int_ForbiddenValues_Empty()
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

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Int_Value_Valid()
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

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Int_Value_Forbidden()
    {
        // Arrange
        var value = 9;

        var forbiddenValues = new int[] { 568, 112, 9 };

        var expectedErrorCode = ErrorCodes.FORBIDDEN;

        // Act
        var act = new ValidationsContract<int>(value)
            .RuleFor("Fake")
            .ForbiddenValue(forbiddenValues);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should().NotBeEmpty();

        act.Notifications.First().ErrorCode
           .Should()
               .Be(expectedErrorCode);
    }
}
