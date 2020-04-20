using DAL.Context.CryptoLearn;
using DAL.Domain.CryptoLearn;
using DAL.IRepositories.CryptoLearn;
using ServiceLayer.Repository.General;

namespace ServiceLayer.Repository.CryptoLearn
{
    public class LessonViewRepository : Repository<LessonView>, ILessonViewRepository
    {
        public LessonViewRepository(CryptoLearnContext context) : base(context)
        {

        }

        public CryptoLearnContext CryptoLearnContext
        {
            get { return Context as CryptoLearnContext; }
        }
    }
}
