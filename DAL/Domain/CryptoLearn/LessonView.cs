using System;

namespace DAL.Domain.CryptoLearn
{
    public class LessonView
    {
        public int Id { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int DeviceId { get; set; }
        public Device Device { get; set; }

        public DateTime LastView { get; set; }
        public int TotalView { get; set; }

    }
}
