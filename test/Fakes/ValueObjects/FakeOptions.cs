namespace PowerUtils.RestAPI.Tests.Fakes.ValueObjects
{
    public record FakeOptions
    {
        public string  Value { get; init; }

        public FakeOptions(string value)
        {
            this.Value = value;
        }
    }
}