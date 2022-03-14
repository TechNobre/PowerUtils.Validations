using System.Linq;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.Validations.Tests.Contracts.Numerics;

public class MinZeroValidationRulesTests
{
    [Fact]
    public void Int_Greater_Valid()
    {
        // Arrange
        var value = 4;


        // Act
        var act = new ValidationsContract<int>(value)
            .RuleFor("Fake")
            .MinZero();


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void Int_Equals_Valid()
    {
        // Arrange
        var value = 0;

        // Act
        var act = new ValidationsContract<int>(value)
            .RuleFor("Fake")
            .MinZero();


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void Int_Less_Invalid()
    {
        // Arrange
        var value = -8;


        // Act
        var act = new ValidationsContract<int>(value)
            .RuleFor("Fake")
            .MinZero();


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().ErrorCode
           .Should()
               .Be(ErrorCodes.GetMinFormatted(0));
    }

    [Fact]
    public void IntNullable_Null_Valid()
    {
        // Arrange
        int? value = null;

        // Act
        var act = new ValidationsContract<int?>(value)
            .RuleFor("Fake")
            .MinZero();


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void IntNullable_Greater_Invalid()
    {
        // Arrange
        int? value = 4;

        // Act
        var act = new ValidationsContract<int?>(value)
            .RuleFor("Fake")
            .MinZero();


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void IntNullable_Equals_Valid()
    {
        // Arrange
        int? value = 6;

        // Act
        var act = new ValidationsContract<int?>(value)
            .RuleFor("Fake")
            .MinZero();


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void IntNullable_Less_Invalid()
    {
        // Arrange
        int? value = -8;

        // Act
        var act = new ValidationsContract<int?>(value)
            .RuleFor("Fake")
            .MinZero();


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().ErrorCode
           .Should()
               .Be(ErrorCodes.GetMinFormatted(0));
    }
}
