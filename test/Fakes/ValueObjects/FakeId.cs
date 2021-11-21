using System;

namespace PowerUtils.Validations.Tests.Fakes.ValueObjects
{
    public record FakeId
    {
        public Guid Id { get; init; }

        public FakeId(Guid id)
        {
            Id = id;
        }
    }
}