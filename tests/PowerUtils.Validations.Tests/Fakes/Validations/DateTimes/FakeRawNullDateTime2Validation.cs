using System;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.Validations.Tests.Fakes.Validations.DateTimes;

public class FakeRawNullDateTime2Validation : ValidationsContract<DateTime?>
{
    private readonly DateTime _minDate;
    private readonly DateTime _maxDate;

    public FakeRawNullDateTime2Validation(
        DateTime? source,
        DateTime minDate,
        DateTime maxDate
    ) : base(source)
    {
        _minDate = minDate;
        _maxDate = maxDate;

        RuleFor(r => r, "FakeDateTime")
            .Date(_minDate, _maxDate);
    }
}
