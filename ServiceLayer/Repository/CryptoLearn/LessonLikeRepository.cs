using DAL.Context.CryptoLearn;
using DAL.Domain.CryptoLearn;
using DAL.IRepositories.CryptoLearn;
using ServiceLayer.Repository.General;

namespace ServiceLayer.Repository.CryptoLearn
{
    public class LessonLikeRepository : Repository<LessonLike>, ILessonLikeRepository
    {
        public LessonLikeRepository(CryptoLearnContext context) : base(context)
        {

        }

        public CryptoLearnContext CryptoLearnContext
        {
            get { return Context as CryptoLearnContext; }
        }
    }
}
