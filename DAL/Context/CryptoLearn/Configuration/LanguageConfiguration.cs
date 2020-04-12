using System.Data.Entity.ModelConfiguration;

namespace DataLayer.Domain.CryptoLearn.Context.Configuration
{
    public class LanguageConfiguration : EntityTypeConfiguration<Language>
    {
        public LanguageConfiguration()
        {
            this.Property(x => x.LanguageName)
                .IsRequired()
                .HasMaxLength(20);

        }
    }
}
