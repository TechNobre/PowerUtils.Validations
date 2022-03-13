using System;

namespace PowerUtils.Validations.Tests.Fakes.Entities;

public class FakeNullDate
{
    public DateTime? Date { get; init; }

    public FakeNullDate(DateTime? date)
        => Date = date;
}
