using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Tests.Fakes.Validations.Strings;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.Strings
{
    public class OptionsIgnoreCaseValidationRulesTests
    {
        [Fact]
        public void NULL_ValidateOptions_Valid()
        {
            // Arrange
            var fake = new FakeOptions(null);
            var options = new string[] { "op1", "Op2" };


            // Act
            var act = new FakeOptionsIgnoreCaseValidation(
                fake,
                options
            );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Empty_ValidateOptions_Valid()
        {
            // Arrange
            var fake = new FakeOptions(string.Empty);
            var options = new string[] { "op1", "Op2" };


            // Act
            var act = new FakeOptionsIgnoreCaseValidation(
                fake,
                options
            );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void InOptions_ValidateOptions_Valid()
        {
            // Arrange
            var fake = new FakeOptions("OP2");
            var options = new string[] { "op1", "Op2" };


            // Act
            var act = new FakeOptionsIgnoreCaseValidation(
                fake,
                options
            );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void OutList_ValidateOptions_Invalid()
        {
            // Arrange
            var fake = new FakeOptions("op3");
            var options = new string[] { "op1", "Op2" };


            // Act
            var act = new FakeOptionsIgnoreCaseValidation(
                fake,
                options
            );


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(nameof(fake.Value));

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.INVALID);
        }

        [Fact]
        public void NullOptions_ValidateOptions_Invalid()
        {
            // Arrange
            var fake = new FakeOptions("op3");
            string[] options = null;


            // Act
            var act = new FakeOptionsIgnoreCaseValidation(
                fake,
                options
            );


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(nameof(FakeOptions.Value));

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.INVALID);
        }
    }
}
