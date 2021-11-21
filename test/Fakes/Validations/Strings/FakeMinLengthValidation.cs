using PowerUtils.RestAPI.Tests.Fakes.Entities;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations.Strings
{
    public class FakeMinLengthValidation : ValidationsContract<FakeEntity>
    {
        private readonly int _minLength;

        public FakeMinLengthValidation(
            FakeEntity source,
            int minLength
        ) : base(source)
        {
            this._minLength = minLength;

            this.RuleFor(r => r.FirstName)
              .MinLength(this._minLength);
        }
    }
}