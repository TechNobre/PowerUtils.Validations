using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.Entities;

namespace PowerUtils.Validations.Tests.Fakes.Validations.Strings
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
            _minLength = minLength;
            _maxLength = maxLength;

            RuleFor(r => r.FirstName)
               .Length(_minLength, _maxLength);
        }
    }
}