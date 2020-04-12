using System.Data.Entity.ModelConfiguration;

namespace DataLayer.Domain.CryptoLearn.Context.Configuration
{
    public class SectionConfiguration : EntityTypeConfiguration<Section>
    {
        public SectionConfiguration()
        {
            this.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
