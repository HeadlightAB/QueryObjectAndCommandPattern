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
            throw new System.NotImplementedException();
        }
    }
}
