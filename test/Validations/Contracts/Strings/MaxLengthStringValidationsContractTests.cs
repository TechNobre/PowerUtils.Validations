using FluentAssertions;
using PowerUtils.RestAPI.Tests.Fakes.Entities;
using PowerUtils.RestAPI.Tests.Fakes.Validations.Strings;
using PowerUtils.Validations;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Strings
{
    public class MaxLengthStringValidationsContractTests
    {
        [Fact]
        public void Value_NULL()
        {
            // Arrange
            FakeEntity fake = new FakeEntity(null);
            int maxLength = 10;


            // Act
            var act = new FakeMaxLengthValidation(
                fake,
                maxLength
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
            FakeEntity fake = new FakeEntity(string.Empty);
            int maxLength = 10;


            // Act
            var act = new FakeMaxLengthValidation(
                fake,
                maxLength
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
            FakeEntity fake = new FakeEntity("value");
            int maxLength = 10;


            // Act
            var act = new FakeMaxLengthValidation(
                fake,
                maxLength
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
            FakeEntity fake = new FakeEntity("value");
            int maxLength = 4;

            string expectedProperty = nameof(fake.FirstName);
            string expectedErrorCode = ErrorCodes.MAX + ":" + maxLength;


            // Act
            var act = new FakeMaxLengthValidation(
                fake,
                maxLength
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