using FluentAssertions;
using PowerUtils.Validations.Exceptions;
using System.Net;
using Xunit;

namespace PowerUtils.RestAPI.Tests.ValidationExceptions;

[Trait("Category", "ValidationExceptions")]
public class BadRequestExceptionTests
{
    [Fact(DisplayName = "Initializes a new instance of the BadRequestException with invalid property and error code - Should have a notifications")]
    public void Constructor_WithPropertyErrorCode_HaveNotifications()
    {
        // Arrange & Act
        var act = new BadRequestException("FakeProperty", "FakeError");


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.BadRequest);

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

    [Fact(DisplayName = "Initializes a new instance of the BadRequestException with empty constructor - Should not have notifications")]
    public void Constructor_Empty_DoesNotHaveNotifications()
    {
        // Arrange & Act
        var act = new BadRequestException();


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.BadRequest);

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact(DisplayName = "Initializes a new instance of the BadRequestException with invalid property, error code and a error message - Should have a notifications")]
    public void Constructor_WithPropertyErrorCodeErrorMessage_HaveNotifications()
    {
        // Arrange & Act
        var act = new BadRequestException("FakeProperty", "FakeError", "Fake message");


        // Assert
        act.StatusCode.Should()
            .Be(HttpStatusCode.BadRequest);

        act.Message.Should()
            .Be("Fake message");

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
}