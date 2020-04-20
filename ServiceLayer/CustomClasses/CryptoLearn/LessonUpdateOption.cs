namespace ServiceLayer.CustomClasses.CryptoLearn
{
    public class LessonUpdateOption
    {
        public LessonUpdateOption()
        {
            this.Option = "";
            this.RightAnswer = false;
        }
        public string Option { get; set; }
        public bool RightAnswer { get; set; }
    }
}