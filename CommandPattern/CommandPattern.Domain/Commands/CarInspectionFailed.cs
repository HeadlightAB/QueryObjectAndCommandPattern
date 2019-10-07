using System;
using CommandPattern.DataAccess.DataSources;

namespace CommandPattern.Domain.Commands
{
    public class CarInspectionFailed : ICommand<Domain.Models.Car, InMemoryDataSource>
    {
        private readonly DateTimeOffset _when;

        public CarInspectionFailed(DateTimeOffset when)
        {
            _when = when;
        }

        public void Execute(Domain.Models.Car domainModel, InMemoryDataSource dataAccess)
        {
            domainModel.ApplyInspectionFailed(_when);

            dataAccess.Store(new DataAccess.Entities.Car
            {
                RegNo = domainModel.RegNo, 
                InspectionApproved = domainModel.InspectionApproved,
                InspectedAt = domainModel.InspectedAt
            });
        }
    }
}
