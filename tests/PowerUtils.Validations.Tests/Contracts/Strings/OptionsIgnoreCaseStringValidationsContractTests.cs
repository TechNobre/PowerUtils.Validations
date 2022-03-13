using System.Linq;
using PowerUtils.Validations;
using PowerUtils.Validations.Tests.Fakes.Validations.Strings;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Strings;

public class OptionsIgnoreCaseStringValidationsContractTests
{
    [Fact]
    public void Value_NULL()
    {
        // Arrange
        var fake = new FakeOptions(null);
        var options = new string[] { "op1", "Op2" };


        // Act
        var act = new FakeOptionsIgnoreCaseValidation(
            fake,
            options
        );


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Value_Empty()
    {
        // Arrange
        var fake = new FakeOptions(string.Empty);
        var options = new string[] { "op1", "Op2" };


        // Act
        var act = new FakeOptionsIgnoreCaseValidation(
            fake,
            options
        );


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Value_Valid()
    {
        // Arrange
        var fake = new FakeOptions("OP2");
        var options = new string[] { "op1", "Op2" };


        // Act
        var act = new FakeOptionsIgnoreCaseValidation(
            fake,
            options
        );


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }

    [Fact]
    public void Value_Invalid()
    {
        // Arrange
        var fake = new FakeOptions("op3");
        var options = new string[] { "op1", "Op2" };

        var expectedProperty = nameof(fake.Value);
        var expectedErrorCode = ErrorCodes.INVALID;


        // Act
        var act = new FakeOptionsIgnoreCaseValidation(
            fake,
            options
        );


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

    [Fact]
    public void Value_Invalid_CustomPropertyName()
    {
        // Arrange
        var fake = new FakeOptions("op3");
        var options = new string[] { "op1", "Op2" };

        var expectedProperty = nameof(FakeOptionsPropertyNameValidation);
        var expectedErrorCode = ErrorCodes.INVALID;


        // Act
        var act = new FakeOptionsPropertyNameValidation(
            fake,
            options
        );


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
}
