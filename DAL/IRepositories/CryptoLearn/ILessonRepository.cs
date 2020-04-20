using DAL.ComplexTypeClasses.CryptoLearn;
using DAL.Domain.CryptoLearn;
using DAL.IRepositories.General;
using System.Collections.Generic;

namespace DAL.IRepositories.CryptoLearn
{
    public interface ILessonRepository : IRepository<Lesson>
    {
        IEnumerable<LessonDetails> GetLessonWithBook(int lessonId);
        IEnumerable<LessonDetails> GetLessonsByBookAndLanguage(int sectionId, int langId);
        IEnumerable<LessonDetailsWithImage> GetLessonsWithImageByBookAndLanguage(int sectionId, int langId);
        //IEnumerable<LessonUpdateDetails> GetLessonDetails(int timeStamp);
        int LessonCount(int langId);
        int MaxAddedTime();
    }
}
