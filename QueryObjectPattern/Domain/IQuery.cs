using DataAccess;

namespace Domain
{
    public interface IQuery<out TDomainModel, in TDataSource> where TDataSource : IDataAccess
    {
        TDomainModel Execute(TDataSource dataSource);
    }
}