using System.Data.Entity.ModelConfiguration;

namespace DataLayer.Domain.CryptoLearn.Context.Configuration
{
    public class DeviceConfiguration : EntityTypeConfiguration<Device>
    {
        public DeviceConfiguration()
        {
            this.Property(x => x.DeviceToken)
                .IsRequired()
                .HasMaxLength(255);

            this.HasMany(x => x.LessonLikes)
                .WithRequired(y => y.Device)
                .HasForeignKey(y => y.DeviceId)
                .WillCascadeOnDelete(true);

            this.HasMany(x => x.LessonViews)
                .WithRequired(y => y.Device)
                .HasForeignKey(y => y.DeviceId)
                .WillCascadeOnDelete(true);
        }
    }
}
