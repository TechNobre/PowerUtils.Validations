namespace PowerUtils.RestAPI.Tests.Fakes.Entities
{
    public class FakeEntity
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public FakeEntity(string firstName) 
        {
            this.FirstName = firstName;
        }

        public FakeEntity(string firstName, string lastName) : this(firstName)
        {
            this.LastName = lastName;
        }
    }
}