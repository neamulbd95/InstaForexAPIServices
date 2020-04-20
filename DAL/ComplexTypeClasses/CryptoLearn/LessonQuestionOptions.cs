namespace DAL.ComplexTypeClasses.CryptoLearn
{
    public class LessonQuestionOptions
    {
        public LessonQuestionOptions()
        {
            this.Option = "";
            this.RightAnswer = false;
        }
        public string Option { get; set; }
        public bool RightAnswer { get; set; }

    }
}
