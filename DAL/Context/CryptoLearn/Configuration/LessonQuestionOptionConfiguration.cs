using DAL.Domain.CryptoLearn;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Context.CryptoLearn.Configuration
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
