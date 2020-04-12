using System.Collections.Generic;

namespace DAL.ComplexTypeClasses.CryptoLearn
{ 
    public class LessonQuestionsDetails
    {
        public string LessonName { get; set; }
        public string Lang { get; set; }
        public IEnumerable<LessonQuestionOptionAnswerDetails> Questions { get; set; }

    }
}
