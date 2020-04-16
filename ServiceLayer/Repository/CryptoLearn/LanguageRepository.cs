using System;
using System.Linq;
using System.Linq.Expressions;
using DAL.Context.CryptoLearn;
using DAL.Domain.CryptoLearn;
using DAL.IRepositories.CryptoLearn;
using ServiceLayer.Repository.General;

namespace ServiceLayer.Repository.CryptoLearn
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(CryptoLearnContext context) : base(context)
        {

        }

        public CryptoLearnContext CryptoLearnContext
        {
            get { return Context as CryptoLearnContext; }
        }

        public Language GetLanguageId(Expression<Func<Language, bool>> condition)
        {
            return CryptoLearnContext.Languages.SingleOrDefault(condition);
        }
    }
}
