using System.Collections.Generic;

namespace DAL.ComplexTypeClasses.CryptoLearn
{
    public class LessonQuestionOptionAnswerDetails
    {
        public LessonQuestionOptionAnswerDetails()
        {
            this.Question = "";
        }
        public string Question { get; set; }
        public IEnumerable<LessonQuestionOptions> Options { get; set; }

    }
}
