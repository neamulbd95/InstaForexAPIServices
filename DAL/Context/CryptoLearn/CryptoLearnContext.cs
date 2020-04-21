using DAL.Context.CryptoLearn.Configuration;
using DAL.Domain.CryptoLearn;
using System.Data.Entity;

namespace DAL.Context.CryptoLearn
{
    public class CryptoLearnContext : DbContext
    {
        public CryptoLearnContext() : base("name=CryptoLearnDB")
        {

        }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonDescription> LessonDescriptions { get; set; }
        public DbSet<LessonDescriptionDiagram> LessonDescriptionDiagrams { get; set; }
        public DbSet<LessonQuestion> LessonQuestions { get; set; }
        public DbSet<LessonQuestionOption> LessonQuestionOptions { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<LessonLike> LessonLikes { get; set; }
        public DbSet<LessonView> LessonViews { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SectionConfiguration());

            modelBuilder.Configurations.Add(new LanguageConfiguration());
            
            modelBuilder.Configurations.Add(new ImageConfiguration());

            modelBuilder.Configurations.Add(new LessonConfiguration());

            modelBuilder.Configurations.Add(new LessonDescriptionConfiguration());

            modelBuilder.Configurations.Add(new LessonDescriptionDiagramConfiguration());

            modelBuilder.Configurations.Add(new LessonQuestionConfiguration());

            modelBuilder.Configurations.Add(new LessonQuestionOptionConfiguration());

            modelBuilder.Configurations.Add(new DeviceConfiguration());

            modelBuilder.Configurations.Add(new LessonViewConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

//Enable-Migrations -ContextTypeName:DAL.Context.CryptoLearn.CryptoLearnContext
//Add-Migration -Configuration DAL.CryptoLearnMigration.Configuration AddingTablesToDatabase
//Update-Database -Configuration DAL.CryptoLearnMigration.Configuration -Verbose