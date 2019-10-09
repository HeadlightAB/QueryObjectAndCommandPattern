using System;

namespace CommandPattern.Domain.Models
{
    public class Car
    {
        public string RegNo { get; }
        public bool InspectionApproved { get; private set; }
        public DateTimeOffset InspectedAt { get; private set; }

        public Car(string regNo)
        {
            RegNo = regNo;
        }

        public virtual void ApplyInspectionFailed(DateTimeOffset when)
        {
            InspectedAt = when;
            InspectionApproved = false;
        }

        public virtual void ApplyInspectionApproved(DateTimeOffset when)
        {
            InspectedAt = when;
            InspectionApproved = true;
        }
    }
}
