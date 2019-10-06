using System;
using System.Collections.Generic;
using System.Linq;
using CommandPattern.DataAccess.Entities;

namespace CommandPattern.DataAccess.DataSources
{
    public class InMemoryDataSource : IDataAccess
    {
        public IQueryable<Car> Cars { get; } = new List<Car>
        {
            new Car {RegNo = "GLW975"},
            new Car {RegNo = "RNY293"},
            new Car {RegNo = "TSP372"}
        }.AsQueryable();

        public void InspectionFailed(string regNo, DateTimeOffset when)
        {
            Cars.Where(x => x.RegNo == regNo).ToList().ForEach(x =>
            {
                x.InspectionApproved = false;
                x.InspectedAt = when;
            });
        }
    }
}
