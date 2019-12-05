using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using XLojaDemoWebApi.Interfaces;
using XLojaDemoWebApi.Models;

namespace XLojaDemoWebApi.Repository
{
    public class RepositoryBase<T> : IRepository<T>
        where T : class
    {
        protected readonly XLojaDemoDbContext Context;

        public RepositoryBase(XLojaDemoDbContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public void AddOrUpdate(T entity)
        {
            EntityEntry<T> entry = Context.Entry(entity);

            var primaryKey = entry.Metadata.FindPrimaryKey();
            if (primaryKey != null)
            {
                object[] keys = primaryKey.Properties.
                    Select(x => x.FieldInfo.GetValue(entity)).
                    ToArray();

                T result = Context.Find<T>(keys);
                if (result == null)
                {
                    Context.Add(entity);
                }
                else
                {
                    Context.Entry(result).State = EntityState.Detached;
                    Context.Update(entity);
                }
            }
            Context.SaveChanges();
        }

        public void Delete(Func<T, bool> predicate)
        {
            Context.Set<T>().Where(predicate).ToList().ForEach(p => Context.Set<T>().Remove(p));
            Context.SaveChanges();
        }

        public void DeleteAll()
        {
            Context.Set<T>().ToList().ForEach(p => Context.Set<T>().Remove(p));
            Context.SaveChanges();
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
    }
}
