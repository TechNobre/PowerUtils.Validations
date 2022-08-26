using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Contracts;
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

        [Fact]
        public void BelowMin_ValidateLatitudeNullable_Invalid()
        {
            // Arrange
            double? latitude = -91.145;


            // Act
            var act = new ValidationsContract<double?>(latitude)
                .RuleFor("fakeLatitude")
                .Latitude();


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be("fakeLatitude");

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMinFormatted(-90));
        }

        [Fact]
        public void AboveMax_ValidateLatitudeNullable_Invalid()
        {
            // Arrange
            double? latitude = 91.145;


            // Act
            var act = new ValidationsContract<double?>(latitude)
                .RuleFor("fakeLatitude")
                .Latitude();


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                 .Should()
                     .Be("fakeLatitude");

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMaxFormatted(90));
        }

        [Fact]
        public void NullLatitude_ValidateLatitudeNullable_Valid()
        {
            // Arrange
            double? latitude = null;


            // Act
            var act = new ValidationsContract<double?>(latitude)
                .RuleFor("fakeLatitude")
                .Latitude();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void ValidLatitude_ValidateLatitudeNullable_Valid()
        {
            // Arrange
            double? latitude = 12.45124;


            // Act
            var act = new ValidationsContract<double?>(latitude)
                .RuleFor("fakeLatitude")
                .Latitude();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void BelowMin_ValidateLongitudeNullable_Invalid()
        {
            // Arrange
            double? longitude = -184.145;


            // Act
            var act = new ValidationsContract<double?>(longitude)
                .RuleFor("fakeLongitude")
                .Longitude();


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be("fakeLongitude");

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMinFormatted(-180));
        }

        [Fact]
        public void AboveMax_ValidateLongitudeNullable_Invalid()
        {
            // Arrange
            double? longitude = 184.145;


            // Act
            var act = new ValidationsContract<double?>(longitude)
                .RuleFor("fakeLongitude")
                .Longitude();


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be("fakeLongitude");

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMaxFormatted(180));
        }

        [Fact]
        public void NullLongitude_ValidateLongitudeNullable_Valid()
        {
            // Arrange
            double? longitude = null;


            // Act
            var act = new ValidationsContract<double?>(longitude)
                .RuleFor("fakeLongitude")
                .Longitude();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void ValidLongitude_ValidateLongitudeNullable_Valid()
        {
            // Arrange
            double? longitude = 45.4512;


            // Act
            var act = new ValidationsContract<double?>(longitude)
                .RuleFor("fakeLongitude")
                .Longitude();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }
    }
}
