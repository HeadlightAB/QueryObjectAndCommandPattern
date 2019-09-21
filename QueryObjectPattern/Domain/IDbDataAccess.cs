using System;

namespace Domain
{
    public interface IDbDataAccess : IDataSource
    {
        TDomain[] Query<TDomain, TEntity>(Func<TEntity, bool> filter, Func<TEntity, TDomain> selector)
            where TEntity : class
            where TDomain : class;
    }
}