using System.Collections.Generic;

namespace DataLayer.Domain.CryptoLearn
{
    public class Language
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }

        public IList<Lesson> Lessons { get; set; }
        public IList<LessonDescription> LessonDescriptions { get; set; }
        public IList<LessonQuestion> LessonQuestions { get; set; }

    }
}
