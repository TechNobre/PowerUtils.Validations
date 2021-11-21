using PowerUtils.RestAPI.Tests.Fakes.Entities;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations.General
{
    public class FakeGenderValidation : ValidationsContract<FakeGender>
    {
        public FakeGenderValidation(FakeGender source) : base(source)
        {
            this.RuleFor(r => r.Gender)
               .Gender();
        }
    }
}