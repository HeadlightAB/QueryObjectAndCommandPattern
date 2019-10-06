using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataSources
{
    public class DbDataAccess : IDbDataAccess
    {
        private readonly DbContext _dbContext;

        public DbDataAccess(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TDomainModel[]> Query<TDomainModel, TEntity>(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TDomainModel>> selector) where TDomainModel : class where TEntity : class
        {
            return await _dbContext.Set<TEntity>()
                .Where(filter)
                .Select(selector).ToArrayAsync();
        }
    }
}