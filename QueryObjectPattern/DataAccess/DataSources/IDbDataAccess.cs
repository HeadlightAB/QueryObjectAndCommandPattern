using System;
using System.Threading.Tasks;

namespace DataAccess.DataSources
{
    public interface IDbDataAccess : IDataAccess
    {
        Task<TDomainModel[]> Query<TDomainModel, TEntity>(Func<TEntity, bool> filter, Func<TEntity, TDomainModel> selector)
            where TEntity : class
            where TDomainModel : class;
    }
}