using System;

namespace PowerUtils.RestAPI.Tests.Fakes.ValueObjects
{
    public record FakeId
    {
        public Guid Id { get; init; }

        public FakeId(Guid id)
        {
            this.Id = id;
        }
    }
}