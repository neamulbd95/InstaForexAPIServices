using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace InstaForexAPIServices.Response
{
    public class GeneralResponse<T> 
    {
        [JsonProperty(PropertyName = "responseCode")]
        public HttpStatusCode ResponseCode { get; set; }

        [JsonProperty(PropertyName = "responseMessage")]
        public string ResponseMessage { get; set; }

        [JsonProperty(PropertyName = "result")]
        public IEnumerable<T> Result { get; set; }

    }
}