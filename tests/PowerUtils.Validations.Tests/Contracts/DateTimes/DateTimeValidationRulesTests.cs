using System;
using System.Linq;
using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.Entities;
using PowerUtils.Validations.Tests.Fakes.Validations.DateTimes;

namespace PowerUtils.Validations.Tests.Contracts.DateTimes;

public class DateTimeValidationRulesTests
{
    [Fact]
    public void StringDateTime_NULL_Valid()
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
    public void StringDateTime_Empty_Valid()
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
    public void StringDateTime_WithinRange_Valid()
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
    public void StringDateTime_AboveMax_Invalid()
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
    public void StringDateTime_BelowMin_Invalid()
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
    public void StringDateTime_InvalidDate_Invalid()
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
    public void DateTime_BelowMin_Invalid()
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
    public void DateTime_Null_Valid()
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
    public void DateTimeNulleble_Null_Valid()
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
    public void DateTimeNullable_AboveMax_Invalid()
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
    public void ValidationsContract_CustomProperty_Invalid()
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
    public void StringDateTimeUtcNowMin_Null_Valid()
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
    public void StringDateUtcNow_InvalidDate_Invalid()
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
    public void StringDateTimeUtcNow_BelowMin_Invalid()
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
    public void StringDateTimeUtcNowMax_Null_Valid()
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
    public void StringDateTimeUtcNowMax_InvalidDate_Invalid()
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
    public void StringDateTimeUtcNowMax_AboveMax_Invalid()
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
    public void DateTimeNullable_BelowMin_Invalid()
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
    public void StringMinDateTimeUtcNow_BelowUtcNow_Invalid()
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
    public void StringMinDateTimeUtcNow_AboveUtcNow_Valid()
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
    public void StringMaxDateTimeUtcNow_AboveUtcNow_Invalid()
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
    public void StringMaxDateTimeUtcNow_BelowUtcNow_Valid()
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
