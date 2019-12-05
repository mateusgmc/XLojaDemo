using System;
using System.Collections.Generic;

namespace XLojaDemoWebApi.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        void Add(T entity);

        void AddOrUpdate(T entity);

        void Delete(Func<T, bool> predicate);

        void DeleteAll();

        IEnumerable<T> Get(Func<T, bool> predicate);

        IEnumerable<T> GetAll();
    }
}
