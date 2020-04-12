using System.Data.Entity.ModelConfiguration;

namespace DataLayer.Domain.CryptoLearn.Context.Configuration
{
    public class ImageConfiguration : EntityTypeConfiguration<Image>
    {
        public ImageConfiguration()
        {
            this.Property(x => x.ImageURL)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(x => x.ImageName)
                .HasMaxLength(255);
        }
    }
}
