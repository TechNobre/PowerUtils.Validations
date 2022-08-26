using System;
using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.Entities;

namespace PowerUtils.Validations.Tests.Fakes.Validations.DateTimes
{
    public class FakeStringDateValidation : ValidationsContract<FakeStringDate>
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        public FakeStringDateValidation(
            FakeStringDate source,
            DateTime minDate,
            DateTime maxDate
        ) : base(source)
        {
            _minDate = minDate;
            _maxDate = maxDate;

            RuleFor(r => r.Date)
                .Date(_minDate, _maxDate);
        }
    }
}
