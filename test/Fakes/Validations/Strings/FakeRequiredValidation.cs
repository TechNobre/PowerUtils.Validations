using PowerUtils.RestAPI.Tests.Fakes.Entities;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations.Strings
{
    public class FakeRequiredValidation : ValidationsContract<FakeEntity>
    {
        public FakeRequiredValidation(FakeEntity source) : base(source)
        {
            this.RuleFor(r => r.FirstName)
              .Required();
        }
    }
}