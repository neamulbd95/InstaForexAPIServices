using System.Collections.Generic;

namespace DAL.Domain.CryptoLearn
{
    public class Device
    {
        public int Id { get; set; }
        public string DeviceToken { get; set; }
        public IList<LessonLike> LessonLikes { get; set; }
        public IList<LessonView> LessonViews { get; set; }

    }
}
