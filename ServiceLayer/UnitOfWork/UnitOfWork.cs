using DAL.Context.CryptoLearn;
using DAL.IRepositories.CryptoLearn;
using DAL.UnitOfWork;
using ServiceLayer.Repository.CryptoLearn;

namespace ServiceLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CryptoLearnContext context;

        public UnitOfWork(CryptoLearnContext _context)
        {
            this.context = _context;
            Devices = new DeviceRepository(context);
            Languages = new LanguageRepository(context);
            Lessons = new LessonRepository(context);
            LessonDescriptions = new LessonDescriptionRepository(context);
            LessonQuestionsDetails = new LessonQuestionAndOptionRepository(context);
            Sections = new SectionRepository(context);
            Images = new LessonImageRepository(context);
        }
        public IDeviceRepository Devices { get; private set; }
        public ILanguageRepository Languages { get; private set; }
        public ILessonRepository Lessons { get; private set; }
        public ILessonDescriptionRepository LessonDescriptions { get; private set; }
        public ILessonQuestionAndOptionRepository LessonQuestionsDetails { get; private set; }
        public ISectionRepository Sections { get; private set; }
        public ILessonImageRepository Images { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
