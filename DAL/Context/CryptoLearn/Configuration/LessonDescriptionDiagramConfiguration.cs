using DAL.Domain.CryptoLearn;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Context.CryptoLearn.Configuration
{
    public class LessonDescriptionDiagramConfiguration : EntityTypeConfiguration<LessonDescriptionDiagram>
    {
        public LessonDescriptionDiagramConfiguration()
        {
            this.Property(x => x.DescriptionDiagram)
                .HasMaxLength(300);

            this.Property(x => x.DescriptionDiagramCaption)
                .HasMaxLength(255);
        }
    }
}
