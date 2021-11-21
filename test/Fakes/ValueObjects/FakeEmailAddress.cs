namespace PowerUtils.RestAPI.Tests.Fakes.ValueObjects
{
    public record FakeEmailAddress
    {
        public string EmailAddress { get; init; }

        public FakeEmailAddress(string emailAddress)
        {
            this.EmailAddress = emailAddress;
        }
    }
}