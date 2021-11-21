using System;

namespace PowerUtils.RestAPI.Tests.Fakes.Entities
{
    public class FakeNullDate
    {
        public DateTime? Date { get; init; }

        public FakeNullDate(DateTime? date)
        {
            this.Date = date;
        }
    }
}