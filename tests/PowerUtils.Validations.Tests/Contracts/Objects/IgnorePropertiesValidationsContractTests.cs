﻿using System.Linq;
using PowerUtils.Validations.Tests.Fakes.Validations.Objects;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Validations.Contracts.Objects;

public class IgnorePropertiesValidationsContractTests
{
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
