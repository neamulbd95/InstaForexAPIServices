using System.Collections.Generic;

namespace DAL.Domain.CryptoLearn
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Lesson> Lessons { get; set; }
    }
}
