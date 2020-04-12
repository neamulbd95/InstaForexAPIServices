using DAL.ComplexTypeClasses.CryptoLearn;
using DAL.Domain.CryptoLearn;
using DAL.IRepositories.General;

namespace DAL.IRepositories.CryptoLearn
{
    public interface ILessonQuestionAndOptionRepository : IRepository<LessonQuestion>
    {
        LessonQuestionsDetails GetLessonQuestionsWithDetails(int LessonId, int LanguageId);
    }
}
