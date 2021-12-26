using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Fakes.Validations.Strings;

public class FakeOptionsPropertyNameValidation : ValidationsContract<FakeOptions>
{
    private readonly string[] _options;

    public FakeOptionsPropertyNameValidation(
        FakeOptions source,
        string[] options
    ) : base(source)
    {
        _options = options;

        RuleFor(r => r.Value, nameof(FakeOptionsPropertyNameValidation))
           .Options(_options);
    }
}
