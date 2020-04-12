using System.Collections.Generic;

namespace DAL.ComplexTypeClasses.CryptoLearn
{
    public class LessonQuestionOptionAnswerDetails
    {
        public string Question { get; set; }
        public IEnumerable<LessonQuestionOptions> Options { get; set; }

    }
}
