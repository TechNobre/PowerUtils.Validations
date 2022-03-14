using System.Collections.Generic;
using System.Linq;
using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.Entities;
using PowerUtils.Validations.Tests.Fakes.Validations;

namespace PowerUtils.Validations.Tests.Contracts;

public class ValidationsContractTests
{
    [Fact]
    public void MultiErrors_SameProperty_OnlyError()
    {
        // Arrange
        var fake = new FakeEntity(null, null);


        // Act
        var act = new FakeMultiValidations(fake);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Count.Should()
            .Be(1);

        act.Notifications.First().Property
            .Should()
                .Be(nameof(fake.FirstName));

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.REQUIRED);
    }

    [Fact]
    public void ValidationsContract_AddOtherNullContact_Valid()
    {
        // Arrange
        ValidationsContract<int> contract = null;


        // Act
        var act = new ValidationsContract<int>(5);
        act.AddNotifications(contract);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void ValidationsContract_AddOtherEmptyContact_Valid()
    {
        // Arrange
        var contract = new ValidationsContract<int>(5);


        // Act
        var act = new ValidationsContract<int>(5);
        act.AddNotifications(contract);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void ValidationsContract_AddOtherContact_OneError()
    {
        // Arrange
        var contract = new ValidationsContract<int>(5);
        contract.AddErrorMIN("FakeProp", 10);


        // Act
        var act = new ValidationsContract<int>(5);
        act.AddNotifications(contract);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Count.Should()
            .Be(1);

        act.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.GetMinFormatted(10));
    }

    [Fact]
    public void ValidationsContract_AddOtherWithSameProperty_OneError()
    {
        // Arrange
        var contract = new ValidationsContract<int>(5);
        contract.AddErrorMIN("FakeProp", 10);


        // Act
        var act = new ValidationsContract<int>(5);
        act.AddErrorMIN("FakeProp", 10);
        act.AddNotifications(contract);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Count.Should()
            .Be(1);

        act.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.GetMinFormatted(10));
    }

    [Fact]
    public void ValidationsContract_AddNullValidationtList_Valid()
    {
        // Arrange
        List<ValidationFailure> validations = null;


        // Act
        var act = new ValidationsContract<int>(5);
        act.AddNotifications(validations);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void ValidationsContract_AddEmptyValidationtList_Valid()
    {
        // Arrange
        var validations = new List<ValidationFailure>();


        // Act
        var act = new ValidationsContract<int>(5);
        act.AddNotifications(validations);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void ValidationsContract_TwiceValidation_OneError()
    {
        // Arrange
        var validations = new List<ValidationFailure>
        {
            new()
            {
                Property = "FakeProp",
                ErrorCode = ErrorCodes.REQUIRED
            },
            new()
            {
                Property = "FakeProp",
                ErrorCode = ErrorCodes.REQUIRED
            }
        };


        // Act
        var act = new ValidationsContract<int>(5);
        act.AddNotifications(validations);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Count.Should()
            .Be(1);

        act.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.REQUIRED);
    }

    [Fact]
    public void ValidationsContract_AddValidationFailure_OneError()
    {
        // Arrange
        var validations = new List<ValidationFailure>
        {
            new()
            {
                Property = "FakeProp",
                ErrorCode = ErrorCodes.REQUIRED
            }
        };


        // Act
        var act = new ValidationsContract<int>(5);
        act.AddNotifications(validations);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Count.Should()
            .Be(1);

        act.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.REQUIRED);
    }
}
