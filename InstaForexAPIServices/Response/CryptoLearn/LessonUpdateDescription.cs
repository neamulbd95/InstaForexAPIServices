using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaForexAPIServices.Response.CryptoLearn
{
    public class LessonUpdateDescription
    {
        public LessonUpdateDescription()
        {
            this.Title = "";
            this.Description = "";
            this.Diagram = "";
            this.Caption = "";
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Diagram { get; set; }
        public string Caption { get; set; }

    }
}