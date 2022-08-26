using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Tests.Fakes.Validations.Globalization;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.Globalization
{
    public class LocationValidationRulesTests
    {
        [Fact]
        public void BelowMin_ValidateLatitude_Invalid()
        {
            // Arrange
            var fake = new FakeLocation();
            fake.Latitude = -91.145;
            fake.Longitude = 14.145;


            // Act
            var act = new FakeLocationValidation(fake);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(nameof(fake.Latitude));

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMinFormatted(-90));
        }

        [Fact]
        public void AboveMax_ValidateLatitude_Invalid()
        {
            // Arrange
            var fake = new FakeLocation();
            fake.Latitude = 91.145;
            fake.Longitude = 14.145;


            // Act
            var act = new FakeLocationValidation(fake);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(nameof(fake.Latitude));

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMaxFormatted(90));
        }

        [Fact]
        public void BelowMin_ValidateLongitude_Invalid()
        {
            // Arrange
            var fake = new FakeLocation();
            fake.Latitude = -14.145;
            fake.Longitude = -184.145;



            // Act
            var act = new FakeLocationValidation(fake);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(nameof(fake.Longitude));

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMinFormatted(-180));
        }

        [Fact]
        public void AboveMax_ValidateLongitude_Invalid()
        {
            // Arrange
            var fake = new FakeLocation();
            fake.Latitude = -14.145;
            fake.Longitude = 184.145;


            // Act
            var act = new FakeLocationValidation(fake);


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(nameof(fake.Longitude));

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMaxFormatted(180));
        }

        [Fact]
        public void ValidCoordenates_ValidateLocation_Valid()
        {
            // Arrange
            var fake = new FakeLocation();
            fake.Latitude = -14.145;
            fake.Longitude = 14.145;


            // Act
            var act = new FakeLocationValidation(fake);


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }
    }
}
