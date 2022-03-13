using System.Linq;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.Validations.Tests.Contracts.Numerics;

public class MinValidationsContractTests
{
    [Fact]
    public void Int_Greater()
    {
        // Arrange
        var value = 4;
        var min = 5;

        var expectedErrorCode = ErrorCodes.MIN + ":" + min;


        // Act
        var act = new ValidationsContract<int>(value)
            .RuleFor("Fake")
            .Min(min);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should().NotBeEmpty();

        act.Notifications.First().ErrorCode
           .Should()
               .Be(expectedErrorCode);
    }

    [Fact]
    public void Int_Equals()
    {
        // Arrange
        var value = 6;
        var min = 6;

        // Act
        var act = new ValidationsContract<int>(value)
            .RuleFor("Fake")
            .Min(min);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Int_Less()
    {
        // Arrange
        var value = 8;
        var min = 7;

        // Act
        var act = new ValidationsContract<int>(value)
            .RuleFor("Fake")
            .Min(min);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void IntNull_Greater_Invalid()
    {
        // Arrange
        int? value = 4;
        var min = 5;

        var expectedErrorCode = ErrorCodes.MIN + ":" + min;

        // Act
        var act = new ValidationsContract<int?>(value)
            .RuleFor("Fake")
            .Min(min);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .NotBeEmpty();

        act.Notifications.First().ErrorCode
           .Should()
               .Be(expectedErrorCode);
    }

    [Fact]
    public void IntNull_Null_Valid()
    {
        // Arrange
        int? value = null;
        var min = 6;

        // Act
        var act = new ValidationsContract<int?>(value)
            .RuleFor("Fake")
            .Min(min);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void IntNull_Equals_Valid()
    {
        // Arrange
        int? value = 6;
        var min = 6;

        // Act
        var act = new ValidationsContract<int?>(value)
            .RuleFor("Fake")
            .Min(min);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void IntNull_Less_Valid()
    {
        // Arrange
        int? value = 8;
        var min = 7;

        // Act
        var act = new ValidationsContract<int?>(value)
            .RuleFor("Fake")
            .Min(min);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }
}
