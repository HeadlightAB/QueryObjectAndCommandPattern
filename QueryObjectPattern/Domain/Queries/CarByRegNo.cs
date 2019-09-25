using System.Linq;
using DataAccess.DataSources;

namespace Domain.Queries
{
    public class CarByRegNo : IQuery<Domain.Models.Car, IDbDataAccess>
    {
        private readonly string _regNo;

        public CarByRegNo(string regNo)
        {
            _regNo = regNo;
        }

        public Domain.Models.Car Execute(IDbDataAccess dataSource)
        {
            return dataSource.Query<Models.Car, DataAccess.Entities.Car>(
                entity => entity.RegNo == _regNo, 
                entity => new Domain.Models.Car(entity.RegNo)).SingleOrDefault();
        }
    }
}
