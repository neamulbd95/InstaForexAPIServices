using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaForexAPIServices.Response.CryptoLearn
{
    public class LessonUpdateDetails
    {
        public LessonUpdateDetails()
        {
            this.Id = 0;
            this.LessonName = "";
            this.SectionId = 0;
            this.LanguageId = 0;
            this.ReadDuration = "";
            this.AddTime = 0;
            this.ImageURL = "";
        }
        public int Id { get; set; }
        public string LessonName { get; set; }
        public int SectionId { get; set; }
        public int LanguageId { get; set; }
        public string ReadDuration { get; set; }
        public int AddTime { get; set; }
        public IEnumerable<LessonUpdateDescription> LessonDescriptions { get; set; }
        public string ImageURL { get; set; }
        public IEnumerable<LessonUpdateQuestion> Questions { get; set; }
    }
}