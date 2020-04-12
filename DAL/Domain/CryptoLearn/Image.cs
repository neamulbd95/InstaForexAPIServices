using System.Collections.Generic;

namespace DataLayer.Domain.CryptoLearn
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public string ImageName { get; set; }
        public IList<Lesson> Lesson { get; set; }

    }
}
