using System.Collections.Generic;

namespace DataLayer.Domain.CryptoLearn
{
    public class Lesson
    {
        public int Id { get; set; }
        public string LessonName { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public int ImageId { get; set; }
        public Image Image { get; set; }

        public string ReadDuration { get; set; }
        public int AddTime { get; set; }

        public IList<LessonDescription> LessonDescriptions { get; set; }
        public IList<LessonQuestion> LessonQuestions { get; set; }
        public IList<LessonLike> LessonLikes { get; set; }
        public IList<LessonView> LessonViews { get; set; }

    }
}
