using FluentAssertions;
using PowerUtils.Validations.Exceptions;
using System.Net;
using Xunit;

namespace PowerUtils.Validations.Tests.ValidationExceptions;

[Trait("Category", "ValidationExceptions")]
public class ConflictExceptionTests
{
    [Fact(DisplayName = "Initializes a new instance of the ConflictException with empty constructor - Should not have notifications")]
    public void Constructor_Empty_DoesNotHaveNotifications()
    {
        // Arrange & Act
        var act = new ConflictException();


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.Conflict);

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact(DisplayName = "Initializes a new instance of the ConflictException with invalid property and a error message - Should have a notifications")]
    public void Constructor_WithPropertyErrorMessage_HaveNotifications()
    {
        // Arrange & Act
        var act = new ConflictException("FakeProperty", "Fake message");


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.Conflict);

        act.Message.Should()
            .Be("Fake message");

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.Should()
            .ContainSingle(c =>
                c.Property == "FakeProperty"
                &&
                c.ErrorCode == ErrorCodes.ALREADY_EXISTS
            );
    }
}