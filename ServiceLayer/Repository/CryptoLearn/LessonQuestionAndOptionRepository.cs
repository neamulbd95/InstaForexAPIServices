using DAL.ComplexTypeClasses.CryptoLearn;
using DAL.Context.CryptoLearn;
using DAL.Domain.CryptoLearn;
using DAL.IRepositories.CryptoLearn;
using ServiceLayer.Repository.General;
using System.Linq;

namespace ServiceLayer.Repository.CryptoLearn
{
    public class LessonQuestionAndOptionRepository : Repository<LessonQuestion>, ILessonQuestionAndOptionRepository
    {
        public LessonQuestionAndOptionRepository(CryptoLearnContext context) : base(context)
        {

        }
        public LessonQuestionsDetails GetLessonQuestionsWithDetails(int LessonId, int LanguageId)
        {
            var lessonQuestion = new LessonQuestionsDetails
            {
                LessonName = CryptoLearnContext.Lessons.FirstOrDefault(x => x.Id == LessonId).LessonName,
                Lang = CryptoLearnContext.Languages.FirstOrDefault(x => x.Id == LanguageId).LanguageName,
                Questions = from questions in CryptoLearnContext.LessonQuestions
                            join lesson in CryptoLearnContext.Lessons
                            on questions.LessonID equals lesson.Id

                            where lesson.Id == LessonId && questions.LanguageId == LanguageId

                            select new LessonQuestionOptionAnswerDetails
                            {
                                Question = questions.Question,
                                Options = from option in CryptoLearnContext.LessonQuestionOptions
                                          where option.QuestionId == questions.Id
                                          select new LessonQuestionOptions
                                          {
                                              Option = option.Option,
                                              RightAnswer = option.RightAnswer
                                          }
                            }
            };

            return lessonQuestion;
        }

        public CryptoLearnContext CryptoLearnContext
        {
            get { return Context as CryptoLearnContext; }
        }
    }
}
