using System;

namespace PowerUtils.RestAPI.Tests.Fakes.Entities
{
    public class FakeDate
    {
        public DateTime Date { get; init; }

        public FakeDate(DateTime date)
        {
            this.Date = date;
        }
    }
}