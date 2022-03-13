using System.Linq;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.Validations.Tests.Contracts.PaginationValidations;

public class OrderingDirectionIgnoreCaseValidationsContractTests
{
    [Fact]
    public void OrderingDirection_Null_NotValidate()
    {
        // Arrange
        string value = null;


        // Act
        var act = new ValidationsContract<string>(value)
            .RuleFor("Fake")
            .OrderingDirectionIgnoreCase();


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void OrderingDirection_Empty_NotValidate()
    {
        // Arrange
        var value = string.Empty;


        // Act
        var act = new ValidationsContract<string>(value)
            .RuleFor("Fake")
            .OrderingDirectionIgnoreCase();


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void OrderingDirection_InvalidValue_NotValidate()
    {
        // Arrange
        var value = "fff";


        // Act
        var act = new ValidationsContract<string>(value)
            .RuleFor("Fake")
            .OrderingDirectionIgnoreCase();


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .NotBeEmpty();

        act.Notifications.First().ErrorCode
           .Should()
               .Be(ErrorCodes.INVALID);
    }

    [Fact]
    public void OrderingDirection_asc_Validate()
    {
        // Arrange
        var value = "asc";


        // Act
        var act = new ValidationsContract<string>(value)
            .RuleFor("Fake")
            .OrderingDirectionIgnoreCase();


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().
            BeEmpty();
    }

    [Fact]
    public void OrderingDirection_DeSc_Validate()
    {
        // Arrange
        var value = "DeSc";


        // Act
        var act = new ValidationsContract<string>(value)
            .RuleFor("Fake")
            .OrderingDirectionIgnoreCase();


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().
            BeEmpty();
    }
}
