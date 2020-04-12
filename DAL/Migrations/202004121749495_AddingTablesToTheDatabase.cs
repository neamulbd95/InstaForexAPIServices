namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTablesToTheDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceToken = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LessonLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonId = c.Int(nullable: false),
                        DeviceId = c.Int(nullable: false),
                        CheckLike = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: true)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .Index(t => t.LessonId)
                .Index(t => t.DeviceId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonName = c.String(nullable: false, maxLength: 255),
                        SectionId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                        ReadDuration = c.String(nullable: false, maxLength: 255),
                        AddTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId)
                .Index(t => t.LanguageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageURL = c.String(nullable: false, maxLength: 255),
                        ImageName = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LessonDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        Paragraph = c.String(),
                        LessonId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        DiagramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId)
                .ForeignKey("dbo.LessonDescriptionDiagrams", t => t.DiagramId, cascadeDelete: true)
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: true)
                .Index(t => t.LessonId)
                .Index(t => t.LanguageId)
                .Index(t => t.DiagramId);
            
            CreateTable(
                "dbo.LessonDescriptionDiagrams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DescriptionDiagram = c.String(maxLength: 300),
                        DescriptionDiagramCaption = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LessonQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false, maxLength: 255),
                        LessonID = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId)
                .ForeignKey("dbo.Lessons", t => t.LessonID, cascadeDelete: true)
                .Index(t => t.LessonID)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.LessonQuestionOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Option = c.String(nullable: false, maxLength: 255),
                        QuestionId = c.Int(nullable: false),
                        RightAnswer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LessonQuestions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.LessonViews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonId = c.Int(nullable: false),
                        DeviceId = c.Int(nullable: false),
                        LastView = c.DateTime(nullable: false),
                        TotalView = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lessons", t => t.LessonId, cascadeDelete: true)
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)
                .Index(t => t.LessonId)
                .Index(t => t.DeviceId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LessonViews", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.LessonLikes", "DeviceId", "dbo.Devices");
            DropForeignKey("dbo.Lessons", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.LessonViews", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.LessonQuestions", "LessonID", "dbo.Lessons");
            DropForeignKey("dbo.LessonLikes", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.LessonDescriptions", "LessonId", "dbo.Lessons");
            DropForeignKey("dbo.Lessons", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.LessonQuestionOptions", "QuestionId", "dbo.LessonQuestions");
            DropForeignKey("dbo.LessonQuestions", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.LessonDescriptions", "DiagramId", "dbo.LessonDescriptionDiagrams");
            DropForeignKey("dbo.LessonDescriptions", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Lessons", "ImageId", "dbo.Images");
            DropIndex("dbo.LessonViews", new[] { "DeviceId" });
            DropIndex("dbo.LessonViews", new[] { "LessonId" });
            DropIndex("dbo.LessonQuestionOptions", new[] { "QuestionId" });
            DropIndex("dbo.LessonQuestions", new[] { "LanguageId" });
            DropIndex("dbo.LessonQuestions", new[] { "LessonID" });
            DropIndex("dbo.LessonDescriptions", new[] { "DiagramId" });
            DropIndex("dbo.LessonDescriptions", new[] { "LanguageId" });
            DropIndex("dbo.LessonDescriptions", new[] { "LessonId" });
            DropIndex("dbo.Lessons", new[] { "ImageId" });
            DropIndex("dbo.Lessons", new[] { "LanguageId" });
            DropIndex("dbo.Lessons", new[] { "SectionId" });
            DropIndex("dbo.LessonLikes", new[] { "DeviceId" });
            DropIndex("dbo.LessonLikes", new[] { "LessonId" });
            DropTable("dbo.Sections");
            DropTable("dbo.LessonViews");
            DropTable("dbo.LessonQuestionOptions");
            DropTable("dbo.LessonQuestions");
            DropTable("dbo.LessonDescriptionDiagrams");
            DropTable("dbo.LessonDescriptions");
            DropTable("dbo.Languages");
            DropTable("dbo.Images");
            DropTable("dbo.Lessons");
            DropTable("dbo.LessonLikes");
            DropTable("dbo.Devices");
        }
    }
}
