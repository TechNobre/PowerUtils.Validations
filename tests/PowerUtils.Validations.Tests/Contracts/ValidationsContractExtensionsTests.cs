using System.Linq;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.Validations.Tests.Contracts;

public class ValidationsContractExtensionsTests
{
    [Fact]
    public void ValidationsContract_AddErrorMIN_OneError()
    {
        // Arrange
        var contract = new ValidationsContract<int>(5);


        // Act
        contract.AddErrorMIN("FakeProp", 10);


        // Assert
        contract.Invalid.Should()
            .BeTrue();

        contract.Notifications.Count.Should()
            .Be(1);

        contract.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        contract.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.GetMinFormatted(10));
    }

    [Fact]
    public void ValidationsContract_AddErrorMAX_OneError()
    {
        // Arrange
        var contract = new ValidationsContract<int>(15);


        // Act
        contract.AddErrorMAX("FakeProp", 10);


        // Assert
        contract.Invalid.Should()
            .BeTrue();

        contract.Notifications.Count.Should()
            .Be(1);

        contract.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        contract.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.GetMaxFormatted(10));
    }

    [Fact]
    public void ValidationsContract_AddErrorINVALID_OneError()
    {
        // Arrange
        var contract = new ValidationsContract<string>("fksjfkl");


        // Act
        contract.AddErrorINVALID("FakeProp");


        // Assert
        contract.Invalid.Should()
            .BeTrue();

        contract.Notifications.Count.Should()
            .Be(1);

        contract.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        contract.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.INVALID);
    }

    [Fact]
    public void ValidationsContract_AddErrorREQUIRED_OneError()
    {
        // Arrange
        var contract = new ValidationsContract<string>("");


        // Act
        contract.AddErrorREQUIRED("FakeProp");


        // Assert
        contract.Invalid.Should()
            .BeTrue();

        contract.Notifications.Count.Should()
            .Be(1);

        contract.Notifications.First().Property
            .Should()
                .Be("FakeProp");

        contract.Notifications.First().ErrorCode
            .Should()
                .Be(ErrorCodes.REQUIRED);
    }
}
