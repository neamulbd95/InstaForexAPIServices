using DAL.ComplexTypeClasses.CryptoLearn;
using DAL.Context.CryptoLearn;
using DAL.Domain.CryptoLearn;
using DAL.IRepositories.CryptoLearn;
using ServiceLayer.Repository.General;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Repository.CryptoLearn
{
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(CryptoLearnContext context) : base(context)
        {

        }
        public IEnumerable<LessonDetails> GetLessonsByBookAndLanguage(int sectionId, int langId)
        {
            var lessonDetail = from les in CryptoLearnContext.Lessons
                               join sec in CryptoLearnContext.Sections
                               on les.SectionId equals sec.Id

                               where sec.Id == sectionId && les.LanguageId == langId
                               select new LessonDetails
                               {
                                   Id = les.Id,
                                   LessonName = les.LessonName,
                                   SectionId = les.SectionId,
                                   SectionName = sec.Name,
                                   ReadDuration = les.ReadDuration,
                                   Language = CryptoLearnContext.Languages.FirstOrDefault(x => x.Id == les.LanguageId).LanguageName
                               };

            return lessonDetail.ToList();
        }

        public IEnumerable<LessonDetailsWithImage> GetLessonsWithImageByBookAndLanguage(int sectionId, int langId)
        {
            var lessonDetail = from les in CryptoLearnContext.Lessons
                               join sec in CryptoLearnContext.Sections
                               on les.SectionId equals sec.Id

                               join image in CryptoLearnContext.Images
                               on les.ImageId equals image.Id

                               where sec.Id == sectionId && les.LanguageId == langId

                               select new LessonDetailsWithImage
                               {
                                   Id = les.Id,
                                   LessonName = les.LessonName,
                                   SectionId = les.SectionId,
                                   SectionName = sec.Name,
                                   ReadDuration = les.ReadDuration,
                                   ImageUrl = image.ImageURL,
                                   ImageTitle = image.ImageName,
                                   Language = CryptoLearnContext.Languages.FirstOrDefault(x => x.Id == les.LanguageId).LanguageName
                               };

            return lessonDetail.ToList();
        }

        public IEnumerable<LessonDetails> GetLessonWithBook(int lessonId)
        {            
            var lessonDetail = from les in CryptoLearnContext.Lessons
                               join sec in CryptoLearnContext.Sections
                               on les.SectionId equals sec.Id

                               where les.Id == lessonId
                               select new LessonDetails
                               {
                                   Id = les.Id,
                                   LessonName = les.LessonName,
                                   SectionId = les.SectionId,
                                   SectionName = sec.Name,
                                   ReadDuration = les.ReadDuration,
                                   Language = CryptoLearnContext.Languages.FirstOrDefault(x => x.Id == les.LanguageId).LanguageName
                               };

            return lessonDetail.ToList();

        }

        public int LessonCount(int langId)
        {
            return CryptoLearnContext.Lessons.Where(x => x.LanguageId == langId).Count();
        }

        public int MaxAddedTime()
        {
            return CryptoLearnContext.Lessons.Max(x => x.AddTime);
        }

        public CryptoLearnContext CryptoLearnContext
        {
            get { return Context as CryptoLearnContext; }
        }
    }
}
