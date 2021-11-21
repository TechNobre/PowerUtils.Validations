using PowerUtils.RestAPI.Tests.Fakes.Entities;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations
{
    public class FakeMultiValidations : ValidationsContract<FakeEntity>
    {
        public FakeMultiValidations(FakeEntity source) : base(source)
        {
            this.RuleFor(r => r.FirstName)
                .Required();

            this.RuleFor(r => r.FirstName)
                .Required();
        }
    }
}