using CommandPattern.DataAccess;

namespace CommandPattern.Domain
{
    public interface ICommand<TDomainModel, TDataAccess> where TDataAccess : IDataAccess
    {
        void Execute(TDomainModel domainModel, TDataAccess dataAccess);
    }
}
