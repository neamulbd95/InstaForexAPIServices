namespace DAL.Domain.CryptoLearn
{
    public class LessonLike
    {
        public int Id { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int DeviceId { get; set; }
        public Device Device { get; set; }

        public bool CheckLike { get; set; }

    }
}
