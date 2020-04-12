using DAL.ComplexTypeClasses.CryptoLearn;
using DAL.Domain.CryptoLearn;
using DAL.IRepositories.General;
using System.Collections.Generic;

namespace DAL.IRepositories.CryptoLearn
{
    public interface ILessonDescriptionRepository : IRepository<LessonDescription>
    {
        IEnumerable<LessonDescriptionsDetail> GetLessonDescription(int lessonId, int langId);
    }
}
