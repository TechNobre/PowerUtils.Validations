using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Tests.Fakes.Validations.Objects;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.Objects
{
    public class RequiredObjectValidationRulesTests
    {
        [Fact]
        public void NULLValue_Validate_Invalid()
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
        public void NotNull_Validate_Valid()
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
}
