using ServiceLayer.CustomClasses.CryptoLearn;
using System.Collections.Generic;

namespace InstaForexAPIServices.Response.CryptoLearn
{
    public class UpdatedLesson
    {
        public IEnumerable<LessonUpdateDetails> NewLesson { get; set; }
        public int NewUpdatedTimeStamp { get; set; }
    }
}