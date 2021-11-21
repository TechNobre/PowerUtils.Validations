using PowerUtils.Validations.Contracts;
using System;

namespace PowerUtils.Validations.Tests.Fakes.Validations.DateTimes
{
    public class FakeRawNullDateTime1Validation : ValidationsContract<DateTime?>
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        public FakeRawNullDateTime1Validation(
            DateTime? source,
            DateTime minDate,
            DateTime maxDate
        ) : base(source)
        {
            _minDate = minDate;
            _maxDate = maxDate;

            RuleFor(r => r.Value, "FakeDateTime")
                .Date(_minDate, _maxDate);
        }
    }
}