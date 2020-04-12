using System.Data.Entity.ModelConfiguration;

namespace DataLayer.Domain.CryptoLearn.Context.Configuration
{
    public class LessonViewConfiguration : EntityTypeConfiguration<LessonView>
    {
        public LessonViewConfiguration()
        {
            this.Property(x => x.LastView)
                .IsRequired();

            this.Property(x => x.TotalView)
                .IsRequired();
        }
    }
}
