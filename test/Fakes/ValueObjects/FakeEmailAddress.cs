namespace PowerUtils.Validations.Tests.Fakes.ValueObjects
{
    public record FakeEmailAddress
    {
        public string EmailAddress { get; init; }

        public FakeEmailAddress(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
}