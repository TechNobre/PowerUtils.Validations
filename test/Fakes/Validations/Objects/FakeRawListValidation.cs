using PowerUtils.Validations.Contracts;
using System.Collections.Generic;

namespace PowerUtils.Validations.Tests.Fakes.Validations.Objects
{
    public class FakeRawListValidation : ValidationsContract<List<string>>
    {
        public FakeRawListValidation(List<string> source) : base(source)
        {
            RuleFor(r => r, "FakeProperty")
                .Required();
        }
    }
}