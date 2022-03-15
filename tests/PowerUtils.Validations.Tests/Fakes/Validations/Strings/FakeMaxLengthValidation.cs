using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.Entities;

namespace PowerUtils.Validations.Tests.Fakes.Validations.Strings;

public class FakeMaxLengthValidation : ValidationsContract<FakeEntity>
{
    private readonly int _maxLength;

    public FakeMaxLengthValidation(
        FakeEntity source,
        int maxLength
    ) : base(source)
    {
        _maxLength = maxLength;

        RuleFor(r => r.FirstName)
           .MaxLength(_maxLength);
    }
}
