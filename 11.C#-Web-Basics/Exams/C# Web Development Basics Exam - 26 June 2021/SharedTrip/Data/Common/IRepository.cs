﻿using System.Linq;

namespace SharedTrip.Data.Common
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        int SaveChanges();

        IQueryable<T> All<T>() where T : class;
    }
}