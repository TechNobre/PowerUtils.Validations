using System.Collections.Generic;
using System.Linq;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.Validations.Tests.Contracts.Collections;

public class CollectionValidationRulesTests
{
    [Fact]
    public void Min_Null_Valid()
    {
        // Arrange
        List<string> list = null;
        var min = 3;


        // Act
        var act = new ValidationsContract<List<string>>(list)
            .RuleFor("fake")
            .Min<List<string>, List<string>, string>(min);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void Min_BelowMin_Invalid()
    {
        // Arrange
        var list = new List<string> { "fake1", "fake2" };
        var min = 3;


        // Act
        var act = new ValidationsContract<List<string>>(list)
            .RuleFor("fake")
            .Min<List<string>, List<string>, string>(min);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.GetMinFormatted(min));
    }

    [Fact]
    public void Max_Null_Valid()
    {
        // Arrange
        List<string> list = null;
        var max = 1;


        // Act
        var act = new ValidationsContract<List<string>>(list)
            .RuleFor("fake")
            .Max<List<string>, List<string>, string>(max);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void Max_AboveMax_Invalid()
    {
        // Arrange
        var list = new List<string> { "fake1", "fake2" };
        var max = 1;


        // Act
        var act = new ValidationsContract<List<string>>(list)
            .RuleFor("fake")
            .Max<List<string>, List<string>, string>(max);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.GetMaxFormatted(max));
    }

    [Fact]
    public void Range_Null_Valid()
    {
        // Arrange
        List<string> list = null;
        var min = 3;
        var max = 4;


        // Act
        var act = new ValidationsContract<List<string>>(list)
            .RuleFor("fake")
            .Range<List<string>, List<string>, string>(min, max);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void Range_BelowMin_Invalid()
    {
        // Arrange
        var list = new List<string> { "fake1", "fake2" };
        var min = 3;
        var max = 4;


        // Act
        var act = new ValidationsContract<List<string>>(list)
            .RuleFor("fake")
            .Range<List<string>, List<string>, string>(min, max);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.GetMinFormatted(min));
    }

    [Fact]
    public void Range_AboveMax_Invalid()
    {
        // Arrange
        var list = new List<string> { "fake1", "fake2" };
        var min = 0;
        var max = 1;


        // Act
        var act = new ValidationsContract<List<string>>(list)
            .RuleFor("fake")
            .Range<List<string>, List<string>, string>(min, max);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.GetMaxFormatted(max));
    }
}
