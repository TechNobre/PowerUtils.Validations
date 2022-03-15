using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Fakes.Validations.Strings;

public class FakeOptionsIgnoreCaseValidation : ValidationsContract<FakeOptions>
{
    private readonly string[] _options;

    public FakeOptionsIgnoreCaseValidation(
        FakeOptions source,
        string[] options
    ) : base(source)
    {
        _options = options;

        RuleFor(r => r.Value)
           .OptionsIgnoreCase(_options);
    }
}
