using DAL.Domain.CryptoLearn;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Context.CryptoLearn.Configuration
{
    public class LessonQuestionConfiguration : EntityTypeConfiguration<LessonQuestion>
    {
        public LessonQuestionConfiguration()
        {
            this.Property(x => x.Question)
                .IsRequired()
                .HasMaxLength(255);

            this.HasRequired(x => x.Language)
                .WithMany(y => y.LessonQuestions)
                .HasForeignKey(x => x.LanguageId)
                .WillCascadeOnDelete(false);

            this.HasMany(x => x.LessonQuestionOptions)
                .WithRequired(y => y.LessonQuestion)
                .HasForeignKey(y => y.QuestionId)
                .WillCascadeOnDelete(true);
        }
    }
}
