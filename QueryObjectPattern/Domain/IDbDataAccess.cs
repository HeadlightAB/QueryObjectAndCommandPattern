using System;

namespace Domain
{
    public interface IDbDataAccess : IDataSource
    {
        TDomainModel[] Query<TDomainModel, TEntity>(Func<TEntity, bool> filter, Func<TEntity, TDomainModel> selector)
            where TEntity : class
            where TDomainModel : class;
    }
}