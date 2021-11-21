namespace PowerUtils.RestAPI.Tests.Fakes.ValueObjects
{
    public record FakeCountry
    {
        public string CountryCode { get; init; }

        public FakeCountry()
        {}

        public FakeCountry(string countryCode)
        {
            this.CountryCode = countryCode;
        }
    }
}