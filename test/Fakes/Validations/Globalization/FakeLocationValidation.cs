using PowerUtils.RestAPI.Tests.Fakes.ValueObjects;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations.Globalization
{
    public class FakeLocationValidation : ValidationsContract<FakeLocation>
    {
        public FakeLocationValidation(FakeLocation source) : base(source)
        {
            this.RuleFor(r => r.Latitude)
                .Latitude();

            this.RuleFor(r => r.Longitude)
                .Longitude();
        }
    }
}