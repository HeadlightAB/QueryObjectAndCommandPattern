using System;
using CommandPattern.DataAccess.DataSources;

namespace CommandPattern.Domain.Commands
{
    public class CarInspectionApproved : ICommand<Domain.Models.Car, InMemoryDataSource>
    {
        private readonly DateTimeOffset _when;

        public CarInspectionApproved(DateTimeOffset when)
        {
            _when = when;
        }

        public void Execute(Domain.Models.Car domainModel, InMemoryDataSource dataAccess)
        {
            domainModel.ApplyInspectionApproved(_when);

            dataAccess.Store(new DataAccess.Entities.Car
            {
                RegNo = domainModel.RegNo, 
                InspectedAt = domainModel.InspectedAt,
                InspectionApproved = domainModel.InspectionApproved
            });
        }
    }
}
