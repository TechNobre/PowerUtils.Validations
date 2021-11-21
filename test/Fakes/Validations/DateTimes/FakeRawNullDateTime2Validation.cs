﻿using PowerUtils.Validations.Contracts;
using System;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations.DateTimes
{
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
            this._minDate = minDate;
            this._maxDate = maxDate;

            this.RuleFor(r => r, "FakeDateTime")
                .Date(this._minDate, this._maxDate);
        }
    }
}