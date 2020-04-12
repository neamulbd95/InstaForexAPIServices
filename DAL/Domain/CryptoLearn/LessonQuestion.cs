using System.Collections.Generic;

namespace DataLayer.Domain.CryptoLearn
{
    public class LessonQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }

        public int LessonID { get; set; }
        public Lesson Lesson { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public IList<LessonQuestionOption> LessonQuestionOptions { get; set; }

    }
}
