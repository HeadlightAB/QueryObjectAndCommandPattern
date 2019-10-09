using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandPattern.DataAccess.DataSources
{
    public class InMemoryDataSource : IDataAccess
    {
        public IQueryable<Entities.Car> Cars { get; } = new List<Entities.Car>
        {
            new Entities.Car {RegNo = "GLW975"},
            new Entities.Car {RegNo = "RNY293"},
            new Entities.Car {RegNo = "TSP372"}
        }.AsQueryable();


        public virtual void Store<TEntity>(TEntity entity)
        {
            if (typeof(TEntity) != typeof(Entities.Car))
            {
                throw new InvalidCastException("Unsupported type for this store");
            }

            if (entity is Entities.Car car)
            {
                var carStored = Cars.Single(x => x.RegNo == car.RegNo);
                carStored.InspectedAt = car.InspectedAt;
                carStored.InspectionApproved = car.InspectionApproved;
            }
        }
    }
}
