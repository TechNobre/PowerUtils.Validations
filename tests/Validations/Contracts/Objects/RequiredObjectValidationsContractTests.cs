using System.Linq;
using FluentAssertions;
using PowerUtils.Validations;
using PowerUtils.Validations.Tests.Fakes.Validations.Objects;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Objects;

public class RequiredObjectValidationsContractTests
{
    [Fact]
    public void Value_NULL()
    {
        // Arrange
        var fake = new FakeCollection();
        fake.ValueList = null;

        var expectedProperty = nameof(fake.ValueList);
        var expectedErrorCode = ErrorCodes.REQUIRED;


        // Act
        var act = new FakeRequiredObjectValidation(fake);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.First().Property
            .Should()
                .Be(expectedProperty);

        act.Notifications.First().ErrorCode
            .Should()
                .Be(expectedErrorCode);
    }

    [Fact]
    public void Value_NotNull()
    {
        // Arrange
        var fake = new FakeCollection();
        fake.ValueList = new System.Collections.Generic.List<string>();


        // Act
        var act = new FakeRequiredObjectValidation(fake);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }
}
