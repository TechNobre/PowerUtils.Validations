using PowerUtils.RestAPI.Tests.Fakes.Entities;
using PowerUtils.Validations.Contracts;
using System;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations.DateTimes
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
            this._minDate = minDate;
            this._maxDate = maxDate;

            this.RuleFor(r => r.Date)
                .Date(this._minDate, this._maxDate);
        }
    }
}