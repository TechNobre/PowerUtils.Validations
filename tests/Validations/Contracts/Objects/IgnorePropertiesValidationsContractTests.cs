﻿using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Tests.Fakes.Validations.Objects;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;
using Xunit;

namespace PowerUtils.Validations.Tests.Validations.Contracts.Objects;

public class IgnorePropertiesValidationsContractTests
{
    [Fact]
    public void IgnoreProperty_WithRules()
    {
        // Arrange
        var fake = new FakeCollection();
        fake.ValueList = null;


        // Act
        var act = new FakeRequiredObjectValidation(fake, "ValueList");


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }


    [Fact]
    public void IgnoreProperty_NullRules()
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
}
