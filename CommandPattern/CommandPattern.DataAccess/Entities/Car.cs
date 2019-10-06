using System;

namespace CommandPattern.DataAccess.Entities
{
    public class Car
    {
        public string RegNo { get; set; }
        public bool InspectionApproved { get; set; }
        public DateTimeOffset InspectedAt { get; set; }
    }
}
