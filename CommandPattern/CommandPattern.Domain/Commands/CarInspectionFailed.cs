using System;
using CommandPattern.DataAccess.DataSources;

namespace CommandPattern.Domain.Commands
{
    public class CarInspectionFailed : ICommand<InMemoryDataSource>
    {
        private readonly string _regNo;
        private readonly DateTimeOffset _when;

        public CarInspectionFailed(string regNo, DateTimeOffset when)
        {
            _regNo = regNo;
            _when = when;
        }

        public void Execute(InMemoryDataSource dataAccess)
        {
            dataAccess.InspectionFailed(_regNo, _when);
        }
    }
}
