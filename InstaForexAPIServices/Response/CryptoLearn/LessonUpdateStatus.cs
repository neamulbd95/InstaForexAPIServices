using InstaForexAPIServices.ENum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaForexAPIServices.Response.CryptoLearn
{
    public class LessonUpdateStatus
    {
        public LessonUpdateStatus()
        {
            this.Update = 0;
            this.UpdateCode = LessonUpdateENum.NoUpdate;
            this.UpdateStatus = "";
        }

        public int Update { get; set; }
        public LessonUpdateENum UpdateCode { get; set; }
        public string UpdateStatus { get; set; }
    }
}