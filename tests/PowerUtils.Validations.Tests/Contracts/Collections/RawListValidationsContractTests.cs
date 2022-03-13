﻿using System.Collections.Generic;
using System.Linq;
using PowerUtils.Validations.Tests.Fakes.Validations.Objects;

namespace PowerUtils.Validations.Tests.Validations.Contracts.Collections;

public class RawListValidationsContractTests
{
    [Fact]
    public void Value_Null()
    {
        // Arrange
        List<string> fake = null;

        var expectedProperty = "FakeProperty";
        var expectedErrorCode = ErrorCodes.REQUIRED;


        // Act
        var act = new FakeRawListValidation(
             fake
        );


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Should()
            .NotBeEmpty();

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
        var fake = new List<string> { "fake1", "fake2" };


        // Act
        var act = new FakeRawListValidation(
             fake
        );


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should().BeEmpty();
    }
}