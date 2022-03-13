using System.Linq;
using PowerUtils.Validations.Tests.Fakes.Entities;
using PowerUtils.Validations.Tests.Fakes.Validations;

namespace PowerUtils.Validations.Tests.Contracts;

public class ValidationsContractTests
{
    [Fact]
    public void MultiErrors_SameProperty()
    {
        // Arrange
        var fake = new FakeEntity(null, null);
        var expectedProperty = nameof(fake.FirstName);
        var expectedErrorCode = ErrorCodes.REQUIRED;


        // Act
        var act = new FakeMultiValidations(fake);


        // Assert
        act.Invalid.Should()
            .BeTrue();

        act.Notifications.Count.Should()
            .Be(1);

        act.Notifications.First().Property
            .Should()
                .Be(expectedProperty);

        act.Notifications.First().ErrorCode
            .Should()
                .Be(expectedErrorCode);
    }
}
