namespace InstaForexAPIServices.Response.CryptoLearn
{
    public class LessonLikeViewResponse
    {
        public LessonLikeViewResponse()
        {
            this.TotalLikes = 0;
            this.TotalViews = 0;
        }
        public int LessonId { get; set; }
        public int TotalLikes { get; set; }
        public int TotalViews { get; set; }
    }
}