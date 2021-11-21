using PowerUtils.RestAPI.Tests.Fakes.ValueObjects;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations.Strings
{
    public class FakeOptionsValidation : ValidationsContract<FakeOptions>
    {
        private readonly string[] _options;

        public FakeOptionsValidation(
            FakeOptions source,
            string[] options
        ) : base(source)
        {
            this._options = options;

            this.RuleFor(r => r.Value)
               .Options(this._options);
        }
    }
}