using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Fakes.Validations.Globalization;

public class FakeCountryValidation : ValidationsContract<FakeCountry>
{
    public FakeCountryValidation(FakeCountry source)
        : base(source)
        => RuleFor(r => r.CountryCode)
            .CountryCodeISO2();
}
