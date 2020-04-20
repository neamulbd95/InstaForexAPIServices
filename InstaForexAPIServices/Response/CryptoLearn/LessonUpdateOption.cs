
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaForexAPIServices.Response.CryptoLearn
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