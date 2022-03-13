using System.Linq;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.Validations.Tests.Contracts.Numerics;

public class MaxValidationsContractTests
{
    [Fact]
    public void Int_Less()
    {
        // Arrange
        var value = 4;
        var max = 5;


        // Act
        var act = new ValidationsContract<int>(value)
            .RuleFor("Fake")
            .Max(max);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Int_Equals()
    {
        // Arrange
        var value = 6;
        var max = 6;


        // Act
        var act = new ValidationsContract<int>(value)
            .RuleFor("Fake")
            .Max(max);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Int_Greater()
    {
        // Arrange
        var value = 8;
        var max = 7;

        var expectedErrorCode = ErrorCodes.MAX + ":" + max;

        // Act
        var act = new ValidationsContract<int>(value)
            .RuleFor("Fake")
            .Max(max);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should().NotBeEmpty();

        act.Notifications.First().ErrorCode
           .Should()
               .Be(expectedErrorCode);
    }

    [Fact]
    public void IntNull_Null_Valid()
    {
        // Arrange
        int? value = null;


        // Act
        var act = new ValidationsContract<int?>(value)
            .RuleFor("Fake")
            .Max(5);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().
            BeEmpty();
    }

    [Fact]
    public void IntNull_Less_Valid()
    {
        // Arrange
        int? value = 4;


        // Act
        var act = new ValidationsContract<int?>(value)
            .RuleFor("Fake")
            .Max(5);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().
            BeEmpty();
    }

    [Fact]
    public void IntNull_Equals_Valid()
    {
        // Arrange
        int? value = 6;


        // Act
        var act = new ValidationsContract<int?>(value)
            .RuleFor("Fake")
            .Max(6);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void IntNull_Greater_Invalid()
    {
        // Arrange
        int? value = 8;
        var max = 7;


        // Act
        var act = new ValidationsContract<int?>(value)
            .RuleFor("Fake")
            .Max(max);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .NotBeEmpty();

        act.Notifications.First().ErrorCode
           .Should()
               .Be(ErrorCodes.MAX + ":" + max);
    }
}
