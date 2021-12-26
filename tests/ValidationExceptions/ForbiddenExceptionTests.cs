using System.Net;
using FluentAssertions;
using PowerUtils.Net.Constants;
using PowerUtils.Validations.Exceptions;
using Xunit;

namespace PowerUtils.Validations.Tests.ValidationExceptions;

[Trait("Category", "ValidationExceptions")]
public class ForbiddenExceptionTests
{
    [Fact(DisplayName = "Initializes a new instance of the ForbiddenException with empty constructor - Should not have notifications")]
    public void Constructor_Empty_DoesNotHaveNotifications()
    {
        // Arrange & Act
        var act = new ForbiddenException();


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.Forbidden);

        act.HelpLink.Should()
            .Be(StatusCodeLink.GetStatusCodeLink((int)HttpStatusCode.Forbidden));

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact(DisplayName = "Initializes a new instance of the ForbiddenException with invalid property and a error message - Should have a notifications")]
    public void Constructor_WithPropertyErrorMessage_HaveNotifications()
    {
        // Arrange & Act
        var act = new ForbiddenException("FakeProperty", "Fake message");


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.Forbidden);

        act.HelpLink.Should()
            .Be(StatusCodeLink.GetStatusCodeLink((int)HttpStatusCode.Forbidden));

        act.Message.Should()
            .Be("Fake message");

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.Should()
            .ContainSingle(c =>
                c.Property == "FakeProperty"
                &&
                c.ErrorCode == ErrorCodes.FORBIDDEN
            );
    }
}
