namespace Domain
{
    public interface IQuery<out TDomainModel, in TDataSource> where TDataSource : IDataSource
    {
        TDomainModel Execute(TDataSource dataSource);
    }
}