namespace DataLayer.Domain.CryptoLearn
{
    public class LessonQuestionOption
    {
        public int Id { get; set; }
        public string Option { get; set; }
        public int QuestionId { get; set; }
        public LessonQuestion LessonQuestion { get; set; }
        public bool RightAnswer { get; set; }

    }
}
