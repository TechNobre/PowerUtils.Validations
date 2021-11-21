using PowerUtils.Validations;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.ErrorCodesTests
{
    [Trait("Category", "Get validation code formatted")]
    public class GetErrorCodesFormattedTests
    {
        [Fact(DisplayName = "String - Get MIN formatted")]
        public void String_GetFormatted_MIN()
        {
            // Arrange
            string min = "0.01";


            // Act
            var act = ErrorCodes.GetMinFormatted(min);


            // Assert
            Assert.Equal(ErrorCodes.MIN + ":0.01", act);
        }

        [Fact(DisplayName = "String - Get MAX formatted")]
        public void String_GetFormatted_MAX()
        {
            // Arrange
            var max = "9.99";


            // Act
            var act = ErrorCodes.GetMaxFormatted(max);


            // Assert
            Assert.Equal(ErrorCodes.MAX + ":9.99", act);
        }

        [Fact(DisplayName = "Double - Get MIN formatted")]
        public void Double_GetFormatted_MIN()
        {
            // Arrange
            var min = 0.01;


            // Act
            var act = ErrorCodes.GetMinFormatted(min);


            // Assert
            Assert.Equal(ErrorCodes.MIN + ":0.01", act);
        }

        [Fact(DisplayName = "Double - Get MAX formatted")]
        public void Double_GetFormatted_MAX()
        {
            // Arrange
            var max = 9.99;


            // Act
            var act = ErrorCodes.GetMaxFormatted(max);


            // Assert
            Assert.Equal(ErrorCodes.MAX + ":9.99", act);
        }

        [Fact(DisplayName = "Get MIN formatted")]
        public void GetFormatted_MIN()
        {
            // Arrange
            var min = 45;


            // Act
            var act = ErrorCodes.GetMinFormatted(min);


            // Assert
            Assert.Equal(ErrorCodes.MIN + ":" + min, act);
        }

        [Fact(DisplayName = "Get MAX formatted")]
        public void GetFormatted_MAX()
        {
            // Arrange
            var max = 45;


            // Act
            var act = ErrorCodes.GetMaxFormatted(max);


            // Assert
            Assert.Equal(ErrorCodes.MAX + ":" + max, act);
        }
    }
}