using PowerUtils.RestAPI.Tests.Fakes.ValueObjects;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations.Objects
{
    public class FakeRequiredObjectValidation : ValidationsContract<FakeCollection>
    {
        public FakeRequiredObjectValidation(FakeCollection source) : base(source)
        {
            this.RuleFor(r => r.ValueList)
                .Required();
        }
        public FakeRequiredObjectValidation(FakeCollection source, params string[] ignoreProperties) : base(source, ignoreProperties)
        {
        }
    }
}