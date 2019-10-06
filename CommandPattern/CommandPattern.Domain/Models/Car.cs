using System;

namespace CommandPattern.Domain.Models
{
    public class Car
    {
        public string RegNo { get; }
        public bool InspectionApproved { get; }
        public DateTimeOffset InpsectedAt { get; }

        public Car(string regNo)
        {
            RegNo = regNo;
        }
    }
}
