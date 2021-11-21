using FluentAssertions;
using PowerUtils.Validations;
using PowerUtils.Validations.Tests.Fakes.Entities;
using PowerUtils.Validations.Tests.Fakes.Validations.Strings;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Strings
{
    public class MinLengthStringValidationsContractTests
    {
        [Fact]
        public void Value_NULL()
        {
            // Arrange
            var fake = new FakeEntity(null);
            int minLength = 10;


            // Act
            var act = new FakeMinLengthValidation(
                fake,
                minLength
            );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Empty()
        {
            // Arrange
            var fake = new FakeEntity(string.Empty);
            int minLength = 10;


            // Act
            var act = new FakeMinLengthValidation(
                fake,
                minLength
            );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Valid()
        {
            // Arrange
            var fake = new FakeEntity("value");
            int minLength = 3;


            // Act
            var act = new FakeMinLengthValidation(
                fake,
                minLength
            );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Invalid()
        {
            // Arrange
            var fake = new FakeEntity("value");
            int minLength = 10;

            string expectedProperty = nameof(fake.FirstName);
            string expectedErrorCode = ErrorCodes.MIN + ":" + minLength;


            // Act
            var act = new FakeMinLengthValidation(
                fake,
                minLength
            );


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should().NotBeEmpty();

            act.Notifications.First().Property
                .Should()
                    .Be(expectedProperty);

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(expectedErrorCode);
        }
    }
}