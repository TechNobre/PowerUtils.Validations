using FluentAssertions;
using PowerUtils.RestAPI.Tests.Fakes.Entities;
using PowerUtils.RestAPI.Tests.Fakes.Validations.DateTimes;
using PowerUtils.Validations;
using PowerUtils.Validations.Contracts;
using System;
using System.Linq;
using Xunit;

namespace PowerUtils.RestAPI.Tests.Validations.Contracts.DateTimes
{
    public class DateDateTimeValidationsContractTests
    {
        [Fact]
        public void Value_NULL_FormatString()
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

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Empty_FormatString()
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

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Valid_FormatString()
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

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void Value_Invalid_Max_FormatString()
        {
            // Arrange
            var fake = new FakeStringDate("2020-06-02");

            var maxDate = new DateTime(2020, 6, 1);
            string expectedProperty = nameof(fake.Date);
            string expectedErrorCode = ErrorCodes.MAX + ":" + maxDate.ToString("yyyy-MM-dd");


            // Act
            var act = new FakeStringDateValidation(
                 fake,
                 new DateTime(2020, 2, 2),
                 maxDate
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

        [Fact]
        public void Value_Invalid_Min_FormatString()
        {
            // Arrange
            var fake = new FakeStringDate("2020-02-01");

            string expectedProperty = nameof(fake.Date);

            var minDate = new DateTime(2020, 2, 2);
            string expectedErrorCode = ErrorCodes.MIN + ":" + minDate.ToString("yyyy-MM-dd");


            // Act
            var act = new FakeStringDateValidation(
                fake,
                minDate,
                new DateTime(2020, 6, 1)
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

        [Fact]
        public void Value_Invalid_FormatString()
        {
            // Arrange
            var fake = new FakeStringDate("20-06-02");

            string expectedProperty = nameof(fake.Date);
            string expectedErrorCode = ErrorCodes.INVALID;


            // Act
            var act = new FakeStringDateValidation(
                 fake,
                 new DateTime(2020, 2, 2),
                 new DateTime(2020, 6, 1)
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

        [Fact]
        public void Value_Invalid_Min_FormatDateTime()
        {
            // Arrange
            var fake = new FakeDate(new DateTime(2020, 02, 01));

            string expectedProperty = nameof(fake.Date);

            var minDate = new DateTime(2020, 2, 2);
            string expectedErrorCode = ErrorCodes.MIN + ":" + minDate.ToString("yyyy-MM-dd");

            // Act
            var act = new FakeDateValidation(
                 fake,
                 minDate,
                 new DateTime(2020, 6, 1)
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

        [Fact]
        public void Value_Invalid_FormatDateTime()
        {
            // Arrange
            var fake = new FakeDate(new DateTime(1020, 02, 01));

            string expectedProperty = nameof(fake.Date);

            var minDate = new DateTime(2020, 2, 2);
            string expectedErrorCode = ErrorCodes.MIN + ":" + minDate.ToString("yyyy-MM-dd");


            // Act
            var act = new FakeDateValidation(
                 fake,
                 minDate,
                 new DateTime(2020, 6, 1)
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

        [Fact]
        public void Value_Valid_FormatNULLDateTime()
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

            act.Notifications.Should().BeEmpty();
        }

        [Fact]
        public void DateTimeRaw_Null()
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

            act.Notifications.Should().BeEmpty();
        }


        [Fact]
        public void DateTimeRaw_Nullable_NotNull()
        {
            // Arrange
            DateTime? fake = new DateTime(2300, 5,9);

            var maxDate = new DateTime(2020, 6, 1);

            string expectedProperty = "FakeDateTime";
            string expectedErrorCode = ErrorCodes.MAX + ":" + maxDate.ToString("yyyy-MM-dd");


            // Act
            var act = new FakeRawNullDateTime1Validation(
                 fake,
                 new DateTime(2020, 2, 2),
                 maxDate
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


        [Fact]
        public void ValidationsContract_Test_Flow_Property()
        {
            // Arrange
            DateTime? fake = new DateTime(2300, 5, 9);

            var maxDate = new DateTime(2020, 6, 1);

            string expectedProperty = "FakeDateTime";
            string expectedErrorCode = ErrorCodes.MAX + ":" + maxDate.ToString("yyyy-MM-dd");


            // Act
            var act = new FakeRawNullDateTime2Validation(
                 fake,
                 new DateTime(2020, 2, 2),
                 maxDate
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

        [Fact(DisplayName = "Validation DateTime Min UTC now - NullValid")]
        [Trait("Category", "DateTimes")]
        public void PropertyDateTime_MinUtcNow_NullValid()
        {
            // Arrange
            string dateTime = null;


            // Act
            var act = new ValidationsContract<string>(dateTime)
                .RuleFor("FakeProperty")
                .MinDateTimeUtcNow();


            // Assert
            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact(DisplayName = "Validation DateTime Min UTC now - Invalid")]
        [Trait("Category", "DateTimes")]
        public void PropertyDateTime_MinUtcNow_ReturnInvalid()
        {
            // Arrange
            var dateTime = "2015-11-02";


            // Act
            var act = new ValidationsContract<string>(dateTime)
                .RuleFor("FakeProperty")
                .MinDateTimeUtcNow();


            // Assert
            act.Notifications.Should()
                .ContainSingle(c =>
                    c.Property == "FakeProperty"
                    &&
                    c.ErrorCode == ErrorCodes.INVALID
                );
        }

        [Fact(DisplayName = "Validation DateTime Min UTC now - Invalid")]
        [Trait("Category", "DateTimes")]
        public void PropertyDateTime_MinUtcNow_ReturnMinUtcNow()
        {
            // Arrange
            var dateTime = "2015-11-02 12:56";


            // Act
            var act = new ValidationsContract<string>(dateTime)
                .RuleFor("FakeProperty")
                .MinDateTimeUtcNow();


            // Assert
            act.Notifications.Should()
                .ContainSingle(c =>
                    c.Property == "FakeProperty"
                    &&
                    c.ErrorCode == ErrorCodes.MIN_DATETIME_UTCNOW
                );
        }

        [Fact(DisplayName = "Validation DateTime Max UTC now - NullValid")]
        [Trait("Category", "DateTimes")]
        public void PropertyDateTime_MaxUtcNow_NullValid()
        {
            // Arrange
            string dateTime = null;


            // Act
            var act = new ValidationsContract<string>(dateTime)
                .RuleFor("FakeProperty")
                .MaxDateTimeUtcNow();


            // Assert
            act.Notifications.Should()
                .BeEmpty();
        }

        [Fact(DisplayName = "Validation DateTime Max UTC now - Invalid")]
        [Trait("Category", "DateTimes")]
        public void PropertyDateTime_MaxUtcNow_ReturnInvalid()
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

        [Fact(DisplayName = "Validation DateTime Max UTC now - Invalid")]
        [Trait("Category", "DateTimes")]
        public void PropertyDateTime_MaxUtcNow_ReturnMaxUtcNow()
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
    }
}