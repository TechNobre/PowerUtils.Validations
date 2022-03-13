using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Fakes.Validations.Strings;

public class FakeOptionsValidation : ValidationsContract<FakeOptions>
{
    private readonly string[] _options;

    public FakeOptionsValidation(
        FakeOptions source,
        string[] options
    ) : base(source)
    {
        _options = options;

        RuleFor(r => r.Value)
           .Options(_options);
    }
}
