using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaForexAPIServices.Response.IFXGame
{
    public class ErroMessage
    {
        public bool ErrorStatus { get; set; }
        public string Message { get; set; }
    }
}