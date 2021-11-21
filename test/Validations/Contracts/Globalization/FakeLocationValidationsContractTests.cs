using FluentAssertions;
using PowerUtils.RestAPI.Tests.Fakes.Validations.Globalization;
using PowerUtils.RestAPI.Tests.Fakes.ValueObjects;
using PowerUtils.Validations;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.Globalization
{
    public class FakeLocationValidationsContractTests
    {
        [Fact]
        public void Invalid_Latitude_Min()
        {
            // Arrange
            FakeLocation fake = new FakeLocation();
            fake.Latitude = -91.145;
            fake.Longitude = 14.145;

            string expectedProperty = nameof(fake.Latitude);
            string expectedErrorCode = ErrorCodes.MIN + ":" + -90;


            // Act
            var act = new FakeLocationValidation(fake);


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

        [Fact]
        public void Invalid_Latitude_Max()
        {
            // Arrange
            FakeLocation fake = new FakeLocation();
            fake.Latitude = 91.145;
            fake.Longitude = 14.145;

            string expectedProperty = nameof(fake.Latitude);
            string expectedErrorCode = ErrorCodes.MAX + ":" + 90;


            // Act
            var act = new FakeLocationValidation(fake);


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

        [Fact]
        public void Invalid_Longitude_Min()
        {
            // Arrange
            FakeLocation fake = new FakeLocation();
            fake.Latitude = -14.145;
            fake.Longitude = -184.145;

            string expectedProperty = nameof(fake.Longitude);
            string expectedErrorCode = ErrorCodes.MIN + ":" + -180;


            // Act
            var act = new FakeLocationValidation(fake);


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

        [Fact]
        public void Invalid_Longitude_Max()
        {
            // Arrange
            FakeLocation fake = new FakeLocation();
            fake.Latitude = -14.145;
            fake.Longitude = 184.145;

            string expectedProperty = nameof(fake.Longitude);
            string expectedErrorCode = ErrorCodes.MAX + ":" + 180;


            // Act
            var act = new FakeLocationValidation(fake);


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

        [Fact]
        public void Valid_Location()
        {
            // Arrange
            FakeLocation fake = new FakeLocation();
            fake.Latitude = -14.145;
            fake.Longitude = 14.145;


            // Act
            var act = new FakeLocationValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should().BeEmpty();
        }
    }
}