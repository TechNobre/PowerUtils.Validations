using PowerUtils.RestAPI.Tests.Fakes.ValueObjects;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations.Guids
{
    public class FakeIdValidation : ValidationsContract<FakeId>
    {
        public FakeIdValidation(FakeId source) : base(source)
        {
            this.RuleFor(r => r.Id)
                .Required();
        }
    }
}