using PowerUtils.RestAPI.Tests.Fakes.Entities;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations.Strings
{
    public class FakeMaxLengthValidation : ValidationsContract<FakeEntity>
    {
        private readonly int _maxLength;

        public FakeMaxLengthValidation(
            FakeEntity source,
            int maxLength
        ) : base(source)
        {
            this._maxLength = maxLength;

            this.RuleFor(r => r.FirstName)
               .MaxLength(this._maxLength);
        }
    }
}