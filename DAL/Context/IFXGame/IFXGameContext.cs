using DAL.Context.IFXGame.Configuration;
using DAL.Domain.IFXGame;
using System.Data.Entity;

namespace DAL.Context.IFXGame
{
    public class IFXGameContext : DbContext
    {
        public IFXGameContext() : base("name=IFXGameDB")
        {

        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<UserToken> UserToken { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserInfoConfiguration());
            modelBuilder.Configurations.Add(new UserTokenConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
