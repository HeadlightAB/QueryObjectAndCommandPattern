namespace CommandPattern.DataAccess
{
    public interface IDataAccess
    {
        void Store<TEntity>(TEntity entity);
    }
}
