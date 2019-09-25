using DataAccess.DataSources;

namespace Domain.Queries
{
    public class TaxByRegNo : IQuery<float, IApiDataAccess>
    {
        private readonly string _regNo;

        public TaxByRegNo(string regNo)
        {
            _regNo = regNo;
        }

        public float Execute(IApiDataAccess dataSource)
        {
            throw new System.NotImplementedException();
        }
    }
}