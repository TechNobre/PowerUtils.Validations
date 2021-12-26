using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Fakes.Validations.Guids;

public class FakeIdValidation : ValidationsContract<FakeId>
{
    public FakeIdValidation(FakeId source) : base(source)
        => RuleFor(r => r.Id)
            .Required();
}
