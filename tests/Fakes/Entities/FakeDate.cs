using System;

namespace PowerUtils.Validations.Tests.Fakes.Entities
{
    public class FakeDate
    {
        public DateTime Date { get; init; }

        public FakeDate(DateTime date)
        {
            Date = date;
        }
    }
}