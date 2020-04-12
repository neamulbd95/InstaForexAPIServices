using DAL.Domain.CryptoLearn;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Context.CryptoLearn.Configuration
{
    public class LessonDescriptionConfiguration : EntityTypeConfiguration<LessonDescription>
    {
        public LessonDescriptionConfiguration()
        {
            this.Property(x => x.Title)
                .HasMaxLength(255);

            this.HasRequired(x => x.Language)
                .WithMany(y => y.LessonDescriptions)
                .HasForeignKey(x => x.LanguageId)
                .WillCascadeOnDelete(false);

            this.HasRequired(x => x.LessonDescriptionDiagram)
                .WithMany(y => y.LessonDescriptions)
                .HasForeignKey(x => x.DiagramId);
        }
    }
}
