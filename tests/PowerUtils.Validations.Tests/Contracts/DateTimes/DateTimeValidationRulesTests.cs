using System;
using System.Linq;
using FluentAssertions;
using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.Entities;
using PowerUtils.Validations.Tests.Fakes.Validations.DateTimes;
using Xunit;

namespace PowerUtils.Validations.Tests.Contracts.DateTimes
{
    public class DateTimeValidationRulesTests
    {
        [Fact]
        public void NULL_ValidateStringDateTime_Valid()
        {
            // Arrange
            var fake = new FakeStringDate(null);


            // Act
            var act = new FakeStringDateValidation(
                fake,
                new DateTime(2020, 2, 2),
                new DateTime(2020, 6, 1)
            );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Empty_ValidateStringDateTime_Valid()
        {
            // Arrange
            var fake = new FakeStringDate(string.Empty);


            // Act
            var act = new FakeStringDateValidation(
                 fake,
                 new DateTime(2020, 2, 2),
                 new DateTime(2020, 6, 1)
             );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void WithinRange_ValidateStringDateTime_Valid()
        {
            // Arrange
            var fake = new FakeStringDate("2020-03-02");


            // Act
            var act = new FakeStringDateValidation(
                 fake,
                 new DateTime(2020, 2, 2),
                 new DateTime(2020, 6, 1)
            );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void AboveMax_ValidateStringDateTime_Invalid()
        {
            // Arrange
            var fake = new FakeStringDate("2020-06-02");
            var maxDate = new DateTime(2020, 6, 1);


            // Act
            var act = new FakeStringDateValidation(
                 fake,
                 new DateTime(2020, 2, 2),
                 maxDate
             );


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(nameof(fake.Date));

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMaxFormatted(maxDate));
        }

        [Fact]
        public void BelowMin_ValidateStringDateTime_Invalid()
        {
            // Arrange
            var fake = new FakeStringDate("2020-02-01");
            var minDate = new DateTime(2020, 2, 2);


            // Act
            var act = new FakeStringDateValidation(
                fake,
                minDate,
                new DateTime(2020, 6, 1)
            );


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(nameof(fake.Date));

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMinFormatted(minDate));
        }

        [Fact]
        public void InvalidDate_ValidateStringDateTime_Invalid()
        {
            // Arrange
            var fake = new FakeStringDate("20-06-02");

            var expectedProperty = nameof(fake.Date);
            var expectedErrorCode = ErrorCodes.INVALID;


            // Act
            var act = new FakeStringDateValidation(
                 fake,
                 new DateTime(2020, 2, 2),
                 new DateTime(2020, 6, 1)
             );


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
        public void BelowMin_ValidateDateTime_Invalid()
        {
            // Arrange
            var fake = new FakeDate(new DateTime(2020, 02, 01));
            var minDate = new DateTime(2020, 2, 2);

            // Act
            var act = new FakeDateValidation(
                 fake,
                 minDate,
                 new DateTime(2020, 6, 1)
             );


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be(nameof(fake.Date));

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMinFormatted(minDate));
        }

        [Fact]
        public void Null_ValidateDateTime_Valid()
        {
            // Arrange
            var fake = new FakeNullDate(null);


            // Act
            var act = new FakeNullDateValidation(
                 fake,
                 new DateTime(2020, 2, 2),
                 new DateTime(2020, 6, 1)
             );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void Null_ValidateDateTimeNulleble_Valid()
        {
            // Arrange
            DateTime? fake = null;


            // Act
            var act = new FakeRawNullDateTime1Validation(
                 fake,
                 new DateTime(2020, 2, 2),
                 new DateTime(2020, 6, 1)
            );


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void AboveMax_ValidateDateTimeNullable_Invalid()
        {
            // Arrange
            DateTime? fake = new DateTime(2300, 5, 9);
            var maxDate = new DateTime(2020, 6, 1);


            // Act
            var act = new FakeRawNullDateTime1Validation(
                 fake,
                 new DateTime(2020, 2, 2),
                 maxDate
            );


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be("FakeDateTime");

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMaxFormatted(maxDate));
        }

        [Fact]
        public void CustomProperty_ValidateContract_Invalid()
        {
            // Arrange
            DateTime? fake = new DateTime(2300, 5, 9);
            var maxDate = new DateTime(2020, 6, 1);


            // Act
            var act = new FakeRawNullDateTime2Validation(
                 fake,
                 new DateTime(2020, 2, 2),
                 maxDate
            );


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be("FakeDateTime");

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMaxFormatted(maxDate));
        }

        [Fact]
        public void Null_ValidateStringDateTimeUtcNowMin_Valid()
        {
            // Arrange
            string dateTime = null;


            // Act
            var act = new ValidationsContract<string>(dateTime)
                .RuleFor("FakeProperty")
                .MinDateTimeUtcNow();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void InvalidDate_ValidateStringDateUtcNow_Invalid()
        {
            // Arrange
            var dateTime = "2015-11-02";


            // Act
            var act = new ValidationsContract<string>(dateTime)
                .RuleFor("FakeProperty")
                .MinDateTimeUtcNow();


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should()
                .ContainSingle(c =>
                    c.Property == "FakeProperty"
                    &&
                    c.ErrorCode == ErrorCodes.INVALID
                );
        }

        [Fact]
        public void BelowMin_ValidateStringDateTimeUtcNow_Invalid()
        {
            // Arrange
            var dateTime = "2015-11-02 12:56";


            // Act
            var act = new ValidationsContract<string>(dateTime)
                .RuleFor("FakeProperty")
                .MinDateTimeUtcNow();


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.Should()
                .ContainSingle(c =>
                    c.Property == "FakeProperty"
                    &&
                    c.ErrorCode == ErrorCodes.MIN_DATETIME_UTCNOW
                );
        }

        [Fact]
        public void Null_ValidateStringDateTimeUtcNowMax_Valid()
        {
            // Arrange
            string dateTime = null;


            // Act
            var act = new ValidationsContract<string>(dateTime)
                .RuleFor("FakeProperty")
                .MaxDateTimeUtcNow();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void InvalidDate_ValidateStringDateTimeUtcNowMax_Invalid()
        {
            // Arrange
            var dateTime = "2015-11-02";


            // Act
            var act = new ValidationsContract<string>(dateTime)
                .RuleFor("FakeProperty")
                .MaxDateTimeUtcNow();


            // Assert
            act.Notifications.Should()
                .ContainSingle(c =>
                    c.Property == "FakeProperty"
                    &&
                    c.ErrorCode == ErrorCodes.INVALID
                );
        }

        [Fact]
        public void AboveMax_ValidateStringDateTimeUtcNowMax_Invalid()
        {
            // Arrange
            var dateTime = "2115-11-02 12:56";


            // Act
            var act = new ValidationsContract<string>(dateTime)
                .RuleFor("FakeProperty")
                .MaxDateTimeUtcNow();


            // Assert
            act.Notifications.Should()
                .ContainSingle(c =>
                    c.Property == "FakeProperty"
                    &&
                    c.ErrorCode == ErrorCodes.MAX_DATETIME_UTCNOW
                );
        }

        [Fact]
        public void BelowMin_ValidateDateTimeNullable_Invalid()
        {
            // Arrange
            DateTime? fake = new DateTime(2000, 5, 9);
            var minDate = new DateTime(2020, 2, 2);


            // Act
            var act = new FakeRawNullDateTime2Validation(
                 fake,
                 minDate,
                 new DateTime(2020, 6, 1)
            );


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be("FakeDateTime");

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.GetMinFormatted(minDate));
        }

        [Fact]
        public void BelowUtcNow_ValidateStringMinDateTimeUtcNow_Invalid()
        {
            // Arrange
            var fake = "2010-03-02 12:45";


            // Act
            var act = new ValidationsContract<string>(fake)
                 .RuleFor("fake")
                 .MinDateTimeUtcNow();


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be("fake");

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.MIN_DATETIME_UTCNOW);
        }

        [Fact]
        public void AboveUtcNow_ValidateStringMinDateTimeUtcNow_Valid()
        {
            // Arrange
            var fake = DateTime.UtcNow.AddYears(5).ToString("yyyy-MM-dd HH:mm");


            // Act
            var act = new ValidationsContract<string>(fake)
                 .RuleFor("fake")
                 .MinDateTimeUtcNow();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact]
        public void AboveUtcNow_ValidateStringMaxDateTimeUtcNow_Invalid()
        {
            // Arrange
            var fake = DateTime.UtcNow.AddYears(5).ToString("yyyy-MM-dd HH:mm");


            // Act
            var act = new ValidationsContract<string>(fake)
                 .RuleFor("fake")
                 .MaxDateTimeUtcNow();


            // Assert
            act.Invalid.Should()
                .BeTrue();

            act.Notifications.First().Property
                .Should()
                    .Be("fake");

            act.Notifications.First().ErrorCode
                .Should()
                    .Be(ErrorCodes.MAX_DATETIME_UTCNOW);
        }

        [Fact]
        public void BelowUtcNow_ValidateStringMaxDateTimeUtcNow_Valid()
        {
            // Arrange
            var fake = "2010-03-02 12:45";


            // Act
            var act = new ValidationsContract<string>(fake)
                 .RuleFor("fake")
                 .MaxDateTimeUtcNow();


            // Assert
            act.Valid.Should()
                .BeTrue();

            act.Notifications.Should()
                .BeEmpty();
        }
    }
}
