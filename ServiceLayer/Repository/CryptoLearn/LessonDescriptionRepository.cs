using DAL.ComplexTypeClasses.CryptoLearn;
using DAL.Context.CryptoLearn;
using DAL.Domain.CryptoLearn;
using DAL.IRepositories.CryptoLearn;
using ServiceLayer.Repository.General;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Repository.CryptoLearn
{
    public class LessonDescriptionRepository : Repository<LessonDescription>, ILessonDescriptionRepository
    {
        public LessonDescriptionRepository(CryptoLearnContext context) : base(context)
        {

        }

        public CryptoLearnContext CryptoLearnContext
        {
            get { return Context as CryptoLearnContext; }
        }

        public IEnumerable<LessonDescriptionsDetail> GetLessonDescription(int lessonId, int langId)
        {
            var lessonDescription = from des in CryptoLearnContext.LessonDescriptions
                                    join diag in CryptoLearnContext.LessonDescriptionDiagrams
                                    on des.DiagramId equals diag.Id into Temp
                                    from ET in Temp.DefaultIfEmpty()

                                    where des.LessonId == lessonId && des.LanguageId == langId
                                    orderby des.Id
                                    select new LessonDescriptionsDetail
                                    {
                                        Title = des.Title,
                                        Description = des.Paragraph,
                                        Diagram = ET == null ? string.Empty : ET.DescriptionDiagram,
                                        Caption = ET == null ? string.Empty : ET.DescriptionDiagramCaption
                                    };
            return lessonDescription.ToList();
        }
    }
}
