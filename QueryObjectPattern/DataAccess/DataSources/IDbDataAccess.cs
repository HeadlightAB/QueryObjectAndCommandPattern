using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.DataSources
{
    public interface IDbDataAccess : IDataAccess
    {
        Task<TDomainModel[]> Query<TDomainModel, TEntity>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TDomainModel>> selector) where TEntity : class where TDomainModel : class;
    }
}