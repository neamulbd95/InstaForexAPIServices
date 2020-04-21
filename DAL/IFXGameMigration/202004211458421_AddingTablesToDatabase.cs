namespace DAL.IFXGameMigration
{
    using System.Data.Entity.Migrations;

    public partial class AddingTablesToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserInfoId = c.Int(nullable: false),
                        CurrentBalance = c.Double(nullable: false),
                        BalanceForDay = c.Double(nullable: false),
                        NumberProfitDeals = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfo", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(nullable: false, maxLength: 255),
                        NickName = c.String(nullable: false, maxLength: 255),
                        ActiveStatus = c.Boolean(nullable: false,defaultValue:true),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.NickName, unique: true);
            
            CreateTable(
                "dbo.UserTokens",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserInfoId = c.Int(nullable: false),
                        Token = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfo", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTokens", "Id", "dbo.UserInfo");
            DropForeignKey("dbo.UserAccounts", "Id", "dbo.UserInfo");
            DropIndex("dbo.UserTokens", new[] { "Id" });
            DropIndex("dbo.UserInfo", new[] { "NickName" });
            DropIndex("dbo.UserAccounts", new[] { "Id" });
            DropTable("dbo.UserTokens");
            DropTable("dbo.UserInfo");
            DropTable("dbo.UserAccounts");
        }
    }
}
