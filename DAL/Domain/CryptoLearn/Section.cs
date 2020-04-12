using System.Collections.Generic;

namespace DataLayer.Domain.CryptoLearn
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Lesson> Lessons { get; set; }
    }
}
