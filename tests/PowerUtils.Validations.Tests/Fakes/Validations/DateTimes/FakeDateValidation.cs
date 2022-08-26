using System;
using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.Entities;

namespace PowerUtils.Validations.Tests.Fakes.Validations.DateTimes
{
    public class FakeDateValidation : ValidationsContract<FakeDate>
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        public FakeDateValidation(
            FakeDate source,
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
