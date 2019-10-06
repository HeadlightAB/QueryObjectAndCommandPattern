using System;
using System.Linq;
using CommandPattern.DataAccess.DataSources;

namespace CommandPattern.Domain.Commands
{
    public class CarInspectionApproved : ICommand<InMemoryDataSource>
    {
        private readonly string _regNo;
        private readonly DateTimeOffset _when;

        public CarInspectionApproved(string regNo, DateTimeOffset when)
        {
            _regNo = regNo;
            _when = when;
        }

        public void Execute(InMemoryDataSource dataAccess)
        {
            dataAccess.Cars.Where(x => x.RegNo == _regNo).ToList().ForEach(x =>
            {
                x.InspectionApproved = true;
                x.InspectedAt = _when;
            });
        }
    }
}
