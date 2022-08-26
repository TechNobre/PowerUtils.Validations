using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.Entities;

namespace PowerUtils.Validations.Tests.Fakes.Validations.General
{
    public class FakeGenderValidation : ValidationsContract<FakeGender>
    {
        public FakeGenderValidation(FakeGender source) : base(source)
            => RuleFor(r => r.Gender)
                .Gender();
    }
}
