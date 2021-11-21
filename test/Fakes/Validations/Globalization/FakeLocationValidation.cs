using PowerUtils.Validations.Contracts;
using PowerUtils.Validations.Tests.Fakes.ValueObjects;

namespace PowerUtils.Validations.Tests.Fakes.Validations.Globalization
{
    public class FakeLocationValidation : ValidationsContract<FakeLocation>
    {
        public FakeLocationValidation(FakeLocation source) : base(source)
        {
            RuleFor(r => r.Latitude)
                .Latitude();

            RuleFor(r => r.Longitude)
                .Longitude();
        }
    }
}