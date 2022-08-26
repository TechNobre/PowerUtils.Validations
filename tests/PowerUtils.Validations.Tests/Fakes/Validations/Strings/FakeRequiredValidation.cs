using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.Entities;

namespace PowerUtils.Validations.Tests.Fakes.Validations.Strings
{
    public class FakeRequiredValidation : ValidationsContract<FakeEntity>
    {
        public FakeRequiredValidation(FakeEntity source) : base(source)
            => RuleFor(r => r.FirstName)
                .Required();
    }
}
