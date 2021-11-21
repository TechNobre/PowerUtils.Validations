using PowerUtils.Validations.Contracts;
using System.Collections.Generic;

namespace PowerUtils.RestAPI.Tests.Fakes.Validations.Objects
{
    public class FakeRawListValidation : ValidationsContract<List<string>>
    {
        public FakeRawListValidation(List<string> source) : base(source)
        {
            this.RuleFor(r => r, "FakeProperty")
                .Required();
        }
    }
}