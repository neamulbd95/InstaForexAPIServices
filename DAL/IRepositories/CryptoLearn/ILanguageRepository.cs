using DAL.Domain.CryptoLearn;
using DAL.IRepositories.General;
using System;
using System.Linq.Expressions;

namespace DAL.IRepositories.CryptoLearn
{
    public interface ILanguageRepository : IRepository<Language>
    {
        Language GetLanguageId(Expression<Func<Language, bool>> condition);
    }
}
