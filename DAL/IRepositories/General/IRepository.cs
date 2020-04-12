using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.IRepositories.General
{
    public interface IRepository<TClass> where TClass : class
    {
        IEnumerable<TClass> GetAll();
        TClass GetByID(int id);
        IEnumerable<TClass> GetByCondition(Expression<Func<TClass, bool>> condition);
        TClass GetSingle(Expression<Func<TClass, bool>> condition);

        void Add(TClass t);

        void Delete(int id);
    }
}
