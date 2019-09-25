using System;

namespace DataAccess.DataSources
{
    public class DbDataAccess : IDbDataAccess
    {
        public DbDataAccess()
        {
        }

        public TDomainModel[] Query<TDomainModel, TEntity>(Func<TEntity, bool> filter, Func<TEntity, TDomainModel> selector) 
            where TDomainModel : class
            where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}