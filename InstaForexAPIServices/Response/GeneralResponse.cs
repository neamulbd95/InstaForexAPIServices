using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

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