using DAL.Context.CryptoLearn;
using DAL.Domain.CryptoLearn;
using DAL.IRepositories.CryptoLearn;
using ServiceLayer.Repository.General;
using System.Linq;

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

        public int GetLessonTotalViews(int lessonId)
        {
            return CryptoLearnContext.LessonViews.Where(x => x.LessonId == lessonId).Sum(x => x.TotalView);
        }
    }
}
