using DAL.Domain.CryptoLearn;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Context.CryptoLearn.Configuration
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
