using System.Collections.Generic;

namespace DAL.Domain.CryptoLearn
{
    public class LessonDescriptionDiagram
    {
        public int Id { get; set; }
        public string DescriptionDiagram { get; set; }
        public string DescriptionDiagramCaption { get; set; }

        public IList<LessonDescription> LessonDescriptions { get; set; }

    }
}
