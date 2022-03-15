using System.Linq;
using PowerUtils.Validations.Tests.Fakes.Validations.Strings;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Contracts.Strings;

public class OptionsValidationRulesTests
{
    [Fact]
    public void Options_NULL_Valid()
    {
        // Arrange
        var fake = new FakeOptions(null);
        var options = new string[] { "op1", "Op2" };


        // Act
        var act = new FakeOptionsValidation(
            fake,
            options
        );


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void Options_Empty_Valid()
    {
        // Arrange
        var fake = new FakeOptions(string.Empty);
        var options = new string[] { "op1", "Op2" };


        // Act
        var act = new FakeOptionsValidation(
            fake,
            options
        );


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void Options_InOptions_Valid()
    {
        // Arrange
        var fake = new FakeOptions("OP2");
        var options = new string[] { "OP2", "Op2" };


        // Act
        var act = new FakeOptionsValidation(
            fake,
            options
        );


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void Options_OutList_Invalid()
    {
        // Arrange
        var fake = new FakeOptions("op3");
        var options = new string[] { "op1", "Op2" };


        // Act
        var act = new FakeOptionsValidation(
            fake,
            options
        );


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().Property
            .Should()
                .Be(nameof(fake.Value));

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.INVALID);
    }

    [Fact]
    public void Value_CustomPropertyName_Invalid()
    {
        // Arrange
        var fake = new FakeOptions("op3");
        var options = new string[] { "op1", "Op2" };


        // Act
        var act = new FakeOptionsPropertyNameValidation(
            fake,
            options
        );


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().Property
            .Should()
                .Be(nameof(FakeOptionsPropertyNameValidation));

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.INVALID);
    }

    [Fact]
    public void Options_NullOptions_Invalid()
    {
        // Arrange
        var fake = new FakeOptions("op3");
        string[] options = null;


        // Act
        var act = new FakeOptionsValidation(
            fake,
            options
        );


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().Property
            .Should()
                .Be(nameof(FakeOptions.Value));

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.INVALID);
    }
}
