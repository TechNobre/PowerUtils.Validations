using System.Net;
using FluentAssertions;
using PowerUtils.Net.Constants;
using PowerUtils.Validations.Exceptions;
using Xunit;

namespace PowerUtils.Validations.Tests.ValidationExceptions;

[Trait("Category", "ValidationExceptions")]
public class UnauthorizedExceptionTests
{
    [Fact(DisplayName = "Initializes a new instance of the BadRequestException with invalid property and error code - Should have a notifications")]
    public void Constructor_WithPropertyErrorCode_HaveNotifications()
    {
        // Arrange & Act
        var act = new UnauthorizedException("FakeProperty", "FakeError");


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.Unauthorized);

        act.HelpLink.Should()
            .Be(StatusCodeLink.GetStatusCodeLink((int)HttpStatusCode.Unauthorized));

        act.Notifications.Should()
            .HaveCount(1);

        act.Notifications.Should()
            .ContainSingle(c =>
                c.Property == "FakeProperty"
                &&
                c.ErrorCode == "FakeError"
            );

        act.Notifications.Should()
            .ContainSingle(c =>
                c.Property == "FakeProperty"
                &&
                c.ErrorCode == "FakeError"
            );
    }

    [Fact(DisplayName = "Initializes a new instance of the UnauthorizedException with empty constructor - Should not have notifications")]
    public void Constructor_Empty_DoesNotHaveNotifications()
    {
        // Arrange & Act
        var act = new UnauthorizedException();


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.Unauthorized);

        act.HelpLink.Should()
            .Be(StatusCodeLink.GetStatusCodeLink((int)HttpStatusCode.Unauthorized));

        act.Notifications.Should()
            .BeEmpty();
    }
}
