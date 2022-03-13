namespace PowerUtils.Validations.Tests.Fakes.ValueObjects;

public record FakeOptions
{
    public string Value { get; init; }

    public FakeOptions(string value)
        => Value = value;
}
