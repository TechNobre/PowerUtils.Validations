using PowerUtils.RestAPI.Tests.Fakes.ValueObjects;
using PowerUtils.Validations.Contracts;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations.Strings
{
    public class FakeOptionsPropertyNameValidation : ValidationsContract<FakeOptions>
    {
        private readonly string[] _options;

        public FakeOptionsPropertyNameValidation(
            FakeOptions source,
            string[] options
        ) : base(source)
        {
            this._options = options;

            this.RuleFor(r => r.Value, nameof(FakeOptionsPropertyNameValidation))
               .Options(this._options);
        }
    }
}