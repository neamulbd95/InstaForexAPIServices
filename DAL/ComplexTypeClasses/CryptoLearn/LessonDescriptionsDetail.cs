﻿using Newtonsoft.Json;

namespace DAL.ComplexTypeClasses.CryptoLearn
{
    public class LessonDescriptionsDetail
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "diagram")]
        public string Diagram { get; set; }

        [JsonProperty(PropertyName = "caption")]
        public string Caption { get; set; }

    }
}
