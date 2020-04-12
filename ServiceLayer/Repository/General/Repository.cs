using DAL.IRepositories.General;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ServiceLayer.Repository.General
{
    public class Repository<TClass> : IRepository<TClass> where TClass : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TClass> dbSet;

        public Repository(DbContext context)
        {
            Context = context;
            dbSet = context.Set<TClass>();
        }

        public void Add(TClass t)
        {
            dbSet.Add(t);           
        }

        public void Delete(int id)
        {
            TClass t = dbSet.Find(id);
            dbSet.Remove(t);
        }

        public IEnumerable<TClass> GetAll()
        {
            return dbSet.ToList();
        }

        public IEnumerable<TClass> GetByCondition(Expression<Func<TClass, bool>> condition)
        {
            return dbSet.Where(condition);
        }

        public TClass GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public TClass GetSingle(Expression<Func<TClass, bool>> condition)
        {
            return dbSet.SingleOrDefault(condition);
        }

    }
}
