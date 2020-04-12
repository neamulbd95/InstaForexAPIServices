using DAL.Domain.CryptoLearn;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Context.CryptoLearn.Configuration
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
