using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Fakes.Validations.Objects;

public class FakeRequiredObjectValidation : ValidationsContract<FakeCollection>
{
    public FakeRequiredObjectValidation(FakeCollection source) : base(source)
        => RuleFor(r => r.ValueList)
            .Required();
}
