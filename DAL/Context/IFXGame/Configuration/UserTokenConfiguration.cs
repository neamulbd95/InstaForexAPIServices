using DAL.Domain.IFXGame;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Context.IFXGame.Configuration
{
    public class UserTokenConfiguration : EntityTypeConfiguration<UserToken>
    {
        public UserTokenConfiguration()
        {
            this.Property(x => x.Token)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
