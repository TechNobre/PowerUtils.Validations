namespace PowerUtils.Validations.Tests.Fakes.ValueObjects;

public record FakeCountry
{
    public string CountryCode { get; init; }

    public FakeCountry()
    { }

    public FakeCountry(string countryCode)
        => CountryCode = countryCode;
}
