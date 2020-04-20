using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaForexAPIServices.Response.CryptoLearn
{
    public class LessonUpdateQuestion
    {
        public LessonUpdateQuestion()
        {
            this.Question = "";           
        }
        public string Question { get; set; }
        public IEnumerable<LessonUpdateOption> Options { get; set; }

    }
}