namespace Domain
{
    public interface IQuery<T>
    {
        T Execute(IDataSource dataSource);
    }
}