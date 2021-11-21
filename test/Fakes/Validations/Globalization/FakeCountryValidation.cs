using PowerUtils.RestAPI.Tests.Fakes.ValueObjects;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations.Globalization
{
    public class FakeCountryValidation : ValidationsContract<FakeCountry>
    {
        public FakeCountryValidation(FakeCountry source) : base(source)
        {
            this.RuleFor(r => r.CountryCode)
               .CountryCodeISO2();
        }
    }
}