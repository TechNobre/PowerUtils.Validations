using PowerUtils.RestAPI.Tests.Fakes.ValueObjects;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations.Strings
{
    public class FakeEmailAddressValidations : ValidationsContract<FakeEmailAddress>
    {
        public FakeEmailAddressValidations(FakeEmailAddress source) : base(source)
        {
            this.RuleFor(r => r.EmailAddress)
               .EmailAddress();
        }
    }
}