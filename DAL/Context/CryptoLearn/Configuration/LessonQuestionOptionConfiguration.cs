using System.Data.Entity.ModelConfiguration;

namespace DataLayer.Domain.CryptoLearn.Context.Configuration
{
    public class LessonQuestionOptionConfiguration : EntityTypeConfiguration<LessonQuestionOption>
    {
        public LessonQuestionOptionConfiguration()
        {
            this.Property(x => x.Option)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(x => x.RightAnswer)
                .IsRequired();
        }
    }
}
