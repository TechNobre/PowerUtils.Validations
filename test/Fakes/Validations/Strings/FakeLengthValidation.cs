using PowerUtils.RestAPI.Tests.Fakes.Entities;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations.Strings
{
    public class FakeLengthValidation : ValidationsContract<FakeEntity>
    {
        private readonly int _minLength;
        private readonly int _maxLength;

        public FakeLengthValidation(
            FakeEntity source,
            int minLength,
            int maxLength
        ) : base(source)
        {
            this._minLength = minLength;
            this._maxLength = maxLength;

            this.RuleFor(r => r.FirstName)
               .Length(this._minLength, this._maxLength);
        }
    }
}