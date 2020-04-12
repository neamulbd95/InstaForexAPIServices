using System.Data.Entity.ModelConfiguration;

namespace DataLayer.Domain.CryptoLearn.Context.Configuration
{
    public class LessonConfiguration : EntityTypeConfiguration<Lesson>
    {
        public LessonConfiguration()
        {
            this.Property(x => x.LessonName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(x => x.ReadDuration)
                .IsRequired()
                .HasMaxLength(255);

            this.HasRequired(x => x.Section)
                .WithMany(y => y.Lessons)
                .HasForeignKey(x => x.SectionId);

            this.HasRequired(x => x.Language)
                .WithMany(y => y.Lessons)
                .HasForeignKey(x => x.LanguageId);

            this.HasRequired(x => x.Image)
                .WithMany(y => y.Lesson)
                .HasForeignKey(x => x.ImageId);

            this.HasMany(x => x.LessonQuestions)
                .WithRequired(y => y.Lesson)
                .HasForeignKey(y => y.LessonID)
                .WillCascadeOnDelete(true);

            this.HasMany(x => x.LessonLikes)
                .WithRequired(y => y.Lesson)
                .HasForeignKey(y => y.LessonId)
                .WillCascadeOnDelete(true);

            this.HasMany(x => x.LessonViews)
                .WithRequired(y => y.Lesson)
                .HasForeignKey(y => y.LessonId)
                .WillCascadeOnDelete(true);

            this.HasMany(x => x.LessonDescriptions)
                .WithRequired(y => y.Lesson)
                .HasForeignKey(y => y.LessonId)
                .WillCascadeOnDelete(true);
        }
    }
}
