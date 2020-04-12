namespace DataLayer.Domain.CryptoLearn
{
    public class LessonDescription
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Paragraph { get; set; }

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public int DiagramId { get; set; }
        public LessonDescriptionDiagram LessonDescriptionDiagram { get; set; }

    }
}
