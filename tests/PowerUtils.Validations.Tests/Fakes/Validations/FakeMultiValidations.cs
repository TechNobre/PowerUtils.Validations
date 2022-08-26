using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.Entities;

namespace PowerUtils.Validations.Tests.Fakes.Validations
{
    public class FakeMultiValidations : ValidationsContract<FakeEntity>
    {
        public FakeMultiValidations(FakeEntity source)
            : base(source)
        {
            RuleFor(r => r.FirstName)
                .Required();

            RuleFor(r => r.FirstName)
                .Required();
        }
    }
}
