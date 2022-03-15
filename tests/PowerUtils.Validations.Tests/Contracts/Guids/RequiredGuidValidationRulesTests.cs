using System;
using System.Linq;
using PowerUtils.Validations.Tests.Fakes.Validations.Guids;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Contracts.Guids;

public class RequiredGuidValidationRulesTests
{
    [Fact]
    public void Guid_Random_Valid()
    {
        // Arrange
        var fake = new FakeId(Guid.NewGuid());


        // Act
        var act = new FakeIdValidation(fake);


        // Assert
        act.Valid.Should()
            .BeTrue();

        act.Notifications.Should()
            .BeEmpty();
    }

    [Fact]
    public void Guid_Empty_Invalid()
    {
        // Arrange
        var fake = new FakeId(Guid.Empty);


        // Act
        var act = new FakeIdValidation(fake);


        // Assert
        act.Valid.Should()
            .BeFalse();

        act.Notifications.First().Property
            .Should()
                .Be(nameof(fake.Id));

        act.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.REQUIRED);
    }
}
