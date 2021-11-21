using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.Entities;

namespace PowerUtils.Validations.Tests.Fakes.Validations.Strings
{
    public class FakeMinLengthValidation : ValidationsContract<FakeEntity>
    {
        private readonly int _minLength;

        public FakeMinLengthValidation(
            FakeEntity source,
            int minLength
        ) : base(source)
        {
            _minLength = minLength;

            RuleFor(r => r.FirstName)
              .MinLength(_minLength);
        }
    }
}