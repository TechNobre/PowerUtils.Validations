using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Fakes.Validations.Strings
{
    public class FakeEmailAddressValidations : ValidationsContract<FakeEmailAddress>
    {
        public FakeEmailAddressValidations(FakeEmailAddress source) : base(source)
        {
            RuleFor(r => r.EmailAddress)
               .EmailAddress();
        }
    }
}