using CommandPattern.DataAccess;

namespace CommandPattern.Domain
{
    public interface ICommand<TDataAccess> where TDataAccess : IDataAccess
    {
        void Execute(TDataAccess dataAccess);
    }
}
