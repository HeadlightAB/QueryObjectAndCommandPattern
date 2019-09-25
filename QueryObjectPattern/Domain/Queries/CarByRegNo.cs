using System.Linq;
using System.Threading.Tasks;
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

        public async Task<Domain.Models.Car> Execute(IDbDataAccess dataSource)
        {
            var result = await dataSource.Query<Models.Car, DataAccess.Entities.Car>(
                entity => entity.RegNo == _regNo, 
                entity => new Domain.Models.Car(entity.RegNo));

            return result.SingleOrDefault();
        }
    }
}
