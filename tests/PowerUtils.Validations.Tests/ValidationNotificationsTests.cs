using System.Collections.Generic;
using System.Linq;
using System.Net;
using PowerUtils.Validations.Contracts;
using PowerUtils.xUnit.Extensions;

namespace PowerUtils.Validations.Tests;

public class ValidationNotificationsTests
{
    [Fact]
    public void Create_WithoutParameters_Valid()
    {
        // Arrange && Act
        var act = new ValidationNotifications();


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(0);
    }

    [Fact]
    public void Create_WithHttpStatusCode_Conflict()
    {
        // Arrange && Act
        var act = new ValidationNotifications(HttpStatusCode.Conflict);


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.Conflict);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(0);
    }

    [Fact]
    public void Notifications_AddPropertyAndError_Invalid()
    {
        // Arrange
        var act = new ValidationNotifications();


        // Act
        act.AddBadNotification("FakeProp", "FakeError");


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.BadRequest);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        act.Notifications.First().ErrorCode
            .Should()
                .Be("FakeError");
    }

    [Fact]
    public void Notifications_AddTwiceSameProperty_Invalid()
    {
        // Arrange
        var act = new ValidationNotifications();


        // Act
        act.AddBadNotification("FakeProp", "FakeError");
        act.AddBadNotification("FakeProp", "FakeError1");


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.BadRequest);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        act.Notifications.First().ErrorCode
            .Should()
                .Be("FakeError");
    }

    [Fact]
    public void Notifications_AddValidationFailure_Invalid()
    {
        // Arrange
        var act = new ValidationNotifications();


        // Act
        act.AddBadNotification(new ValidationFailure
        {
            Property = "FakeProp",
            ErrorCode = ErrorCodes.REQUIRED
        });


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.BadRequest);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.REQUIRED);
    }

    [Fact]
    public void Notifications_AddTwiceValidationFailure_Invalid()
    {
        // Arrange
        var act = new ValidationNotifications();


        // Act
        act.AddBadNotification(new ValidationFailure
        {
            Property = "FakeProp",
            ErrorCode = ErrorCodes.REQUIRED
        });
        act.AddBadNotification(new ValidationFailure
        {
            Property = "FakeProp",
            ErrorCode = ErrorCodes.INVALID
        });


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.BadRequest);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.REQUIRED);
    }

    [Fact]
    public void Notifications_AddEmptyValidationFailureList_Valid()
    {
        // Arrange
        var act = new ValidationNotifications();
        IList<ValidationFailure> validations = new List<ValidationFailure>();


        // Act
        act.AddBadNotifications(validations);


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.OK);


        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(0);
    }

    [Fact]
    public void Notifications_AddValidationFailureList_Invalid()
    {
        // Arrange
        var act = new ValidationNotifications();
        IList<ValidationFailure> validations = new List<ValidationFailure>
        {
            new()
            {
                Property = "FakeProp",
                ErrorCode = ErrorCodes.REQUIRED
            },
            new()
            {
                Property = "FakeProp",
                ErrorCode = ErrorCodes.INVALID
            }
        };


        // Act
        act.AddBadNotifications(validations);


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.BadRequest);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.REQUIRED);
    }

    [Fact]
    public void Notifications_AddEmptyValidationFailureReadOnlyCollection_Valid()
    {
        // Arrange
        var act = new ValidationNotifications();
        IReadOnlyCollection<ValidationFailure> validations = new List<ValidationFailure>();


        // Act
        act.AddBadNotifications(validations);


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.OK);


        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(0);
    }

    [Fact]
    public void Notifications_AddValidationFailureReadOnlyCollection_Invalid()
    {
        // Arrange
        var act = new ValidationNotifications();
        IReadOnlyCollection<ValidationFailure> validations = new List<ValidationFailure>
        {
            new()
            {
                Property = "FakeProp",
                ErrorCode = ErrorCodes.REQUIRED
            },
            new()
            {
                Property = "FakeProp",
                ErrorCode = ErrorCodes.INVALID
            }
        };


        // Act
        act.AddBadNotifications(validations);


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.BadRequest);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.REQUIRED);
    }

    [Fact]
    public void Notifications_AddEmptyValidationFailureICollection_Valid()
    {
        // Arrange
        var act = new ValidationNotifications();
        ICollection<ValidationFailure> validations = new List<ValidationFailure>();


        // Act
        act.AddBadNotifications(validations);


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.OK);


        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(0);
    }

    [Fact]
    public void Notifications_AddValidationFailureICollection_Invalid()
    {
        // Arrange
        var act = new ValidationNotifications();
        ICollection<ValidationFailure> validations = new List<ValidationFailure>
        {
            new()
            {
                Property = "FakeProp",
                ErrorCode = ErrorCodes.REQUIRED
            },
            new()
            {
                Property = "FakeProp",
                ErrorCode = ErrorCodes.INVALID
            }
        };


        // Act
        act.AddBadNotifications(validations);


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.BadRequest);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.REQUIRED);
    }

    [Fact]
    public void Notifications_AddEmptyValidationFailureIEnumerable_Valid()
    {
        // Arrange
        var act = new ValidationNotifications();
        IEnumerable<ValidationFailure> validations = new List<ValidationFailure>();


        // Act
        act.AddBadNotifications(validations);


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.OK);


        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(0);
    }

    [Fact]
    public void Notifications_AddValidationFailureIEnumerable_Invalid()
    {
        // Arrange
        var act = new ValidationNotifications();
        IEnumerable<ValidationFailure> validations = new List<ValidationFailure>
        {
            new()
            {
                Property = "FakeProp",
                ErrorCode = ErrorCodes.REQUIRED
            },
            new()
            {
                Property = "FakeProp",
                ErrorCode = ErrorCodes.INVALID
            }
        };


        // Act
        act.AddBadNotifications(validations);


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.BadRequest);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.REQUIRED);
    }

    [Fact]
    public void Notifications_AddNullContract_Invalid()
    {
        // Arrange
        ValidationsContract<int> contract = null;


        // Act
        var act = new ValidationNotifications();
        act.AddBadNotifications(contract);


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.OK);


        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(0);
    }

    [Fact]
    public void Notifications_AddValidContract_Invalid()
    {
        // Arrange
        var contract = new ValidationsContract<int>(45);


        // Act
        var act = new ValidationNotifications();
        act.AddBadNotifications(contract);


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.OK);


        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(0);
    }

    [Fact]
    public void Notifications_AddContract_Invalid()
    {
        // Arrange
        var contract = new ValidationsContract<int>(5);
        contract.AddErrorREQUIRED("FakeProp");


        // Act
        var act = new ValidationNotifications();
        act.AddBadNotifications(contract);


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.BadRequest);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.REQUIRED);
    }

    [Fact]
    public void Notifications_AddContractWithSameProperty_OneError()
    {
        // Arrange
        var contract = new ValidationsContract<int>(5);
        contract.AddErrorREQUIRED("FakeProp");


        // Act
        var act = new ValidationNotifications();
        act.AddBadNotification("FakeProp", "FakeError");
        act.AddBadNotifications(contract);


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.BadRequest);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        act.Notifications.First().ErrorCode
            .Should()
                .Be("FakeError");
    }

    [Fact]
    public void Notifications_SetForbiddenStatus_Forbidden()
    {
        // Arrange
        var act = new ValidationNotifications();


        // Act
        act.SetForbiddenStatus("Fake3");


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.Forbidden);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.First().Property
            .Should()
                .Be("Fake3");

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.FORBIDDEN);
    }

    [Fact]
    public void Notifications_SetNotFoundStatus_NotFound()
    {
        // Arrange
        var act = new ValidationNotifications();


        // Act
        act.SetNotFoundStatus("Fake4");


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.NotFound);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.First().Property
            .Should()
                .Be("Fake4");

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.NOT_FOUND);
    }

    [Fact]
    public void Notifications_SetConflictStatus_Conflict()
    {
        // Arrange
        var act = new ValidationNotifications();


        // Act
        act.SetConflictStatus("Fake6");


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.Conflict);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.First().Property
            .Should()
                .Be("Fake6");

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.DUPLICATED);
    }

    [Fact]
    public void Notifications_SetNotificationStatus_BadGateway()
    {
        // Arrange
        var act = new ValidationNotifications();


        // Act
        act.SetNotificationStatus(HttpStatusCode.BadGateway, "Fake7", "FakeErr");


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.BadGateway);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.First().Property
            .Should()
                .Be("Fake7");

        act.Notifications.First().ErrorCode
            .Should()
                .Be("FakeErr");
    }

    [Fact]
    public void Notifications_StausOkWithError_Invalid()
    {
        // Arrange
        var act = new ValidationNotifications();


        // Act
        act.SetNotificationStatus(HttpStatusCode.OK, "Fake7", "FakeErr");


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.OK);


        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.First().Property
            .Should()
                .Be("Fake7");

        act.Notifications.First().ErrorCode
            .Should()
                .Be("FakeErr");
    }

    [Fact]
    public void Clear_WithoutErrors_Empty()
    {
        // Arrange
        var act = new ValidationNotifications();


        // Act
        act.Clear();


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.OK);


        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(0);
    }

    [Fact]
    public void Clear_WithBadRequest_Empty()
    {
        // Arrange
        var act = new ValidationNotifications();
        act.SetNotificationStatus(HttpStatusCode.BadRequest, "Fake7", "FakeErr");


        // Act
        act.Clear();


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.OK);


        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .HaveCount(0);
    }

    [Fact]
    public void IsSuccess_StatusOK_True()
    {
        // Arrange && Act
        var notifications = new ValidationNotifications();
        notifications.SetNotificationStatus(HttpStatusCode.OK, "Fake7", "FakeErr");


        // Assert
        var act = notifications.InvokeNonPublicMethod<bool>("_isSuccess");


        act.Should()
            .BeTrue();
    }

    [Fact]
    public void IsSuccess_StatusAccepted_True()
    {
        // Arrange && Act
        var notifications = new ValidationNotifications();
        notifications.SetNotificationStatus(HttpStatusCode.Accepted, "Fake7", "FakeErr");


        // Assert
        var act = notifications.InvokeNonPublicMethod<bool>("_isSuccess");


        act.Should()
            .BeTrue();
    }

    [Fact]
    public void IsSuccess_StatusBadRequest_False()
    {
        // Arrange && Act
        var notifications = new ValidationNotifications();
        notifications.SetNotificationStatus(HttpStatusCode.BadRequest, "Fake7", "FakeErr");


        // Assert
        var act = notifications.InvokeNonPublicMethod<bool>("_isSuccess");


        act.Should()
            .BeFalse();
    }

    [Fact]
    public void IsSuccess_StatusInternalServerError_False()
    {
        // Arrange && Act
        var notifications = new ValidationNotifications();
        notifications.SetNotificationStatus(HttpStatusCode.InternalServerError, "Fake7", "FakeErr");


        // Assert
        var act = notifications.InvokeNonPublicMethod<bool>("_isSuccess");


        act.Should()
            .BeFalse();
    }

    [Fact]
    public void IsSuccess_StatusContinue_True()
    {
        // Arrange && Act
        var notifications = new ValidationNotifications();
        notifications.SetNotificationStatus(HttpStatusCode.Continue, "Fake7", "FakeErr");


        // Assert
        var act = notifications.InvokeNonPublicMethod<bool>("_isSuccess");


        act.Should()
            .BeFalse();
    }
}
