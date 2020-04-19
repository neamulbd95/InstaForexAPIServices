using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaForexAPIServices.RequestInputClass.CryptoLearn
{
    public class LessonUpdateCheck
    {
        public int ClientTimeStamp { get; set; }
        public int LessonCount { get; set; }
        public string Language { get; set; }
    }
}