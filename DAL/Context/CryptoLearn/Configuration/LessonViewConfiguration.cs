using DAL.Domain.CryptoLearn;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Context.CryptoLearn.Configuration
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
