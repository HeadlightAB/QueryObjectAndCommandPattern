﻿using System;

namespace Domain
{
    public interface IDbDataAccess : IDataAccess
    {
        TDomainModel[] Query<TDomainModel, TEntity>(Func<TEntity, bool> filter, Func<TEntity, TDomainModel> selector)
            where TEntity : class
            where TDomainModel : class;
    }
}