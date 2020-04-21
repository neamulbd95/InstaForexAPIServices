using DAL.Domain.IFXGame;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Context.IFXGame.Configuration
{
    public class UserInfoConfiguration : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoConfiguration()
        {
            this.Property(x => x.AccountNumber)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(x => x.NickName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(x => x.ActiveStatus)
                .IsRequired();

            this.HasIndex(x => x.NickName)
                .IsUnique();

            this.HasOptional(x => x.UserToken)
                .WithRequired(y => y.UserInfo)
                .WillCascadeOnDelete();

            this.HasOptional(x => x.UserAccount)
                .WithRequired(y => y.UserInfo)
                .WillCascadeOnDelete();
        }
    }
}
