using Newtonsoft.Json;

namespace DAL.ComplexTypeClasses.CryptoLearn
{
    public class LessonDetails
    {
        [JsonProperty(PropertyName = "lessonId")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "lessonName")]
        public string LessonName { get; set; }

        [JsonProperty(PropertyName = "bookId")]
        public int SectionId { get; set; }

        [JsonProperty(PropertyName = "bookName")]
        public string SectionName { get; set; }

        [JsonProperty(PropertyName = "readDuration")]
        public string ReadDuration { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }
    }
}
