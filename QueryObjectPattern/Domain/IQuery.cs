using System.Threading.Tasks;
using DataAccess;

namespace Domain
{
    public interface IQuery<TDomainModel, in TDataSource> where TDataSource : IDataAccess
    {
        Task<TDomainModel> Execute(TDataSource dataSource);
    }
}