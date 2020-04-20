using DAL.Domain.CryptoLearn;
using DAL.UnitOfWork;
using ServiceLayer.CustomClasses.CryptoLearn;
using Unity;

namespace ServiceLayer.Services.CryptoLearn
{
    public static class LessonDetailsService
    {
        public static LessonUpdateDetails GetLessonDetails(IUnitOfWork _unitOfWork, Lesson lesson, int langId)
        {
            IUnityContainer container = new UnityContainer();
            var updatedLesson = container.Resolve<LessonUpdateDetails>();

            updatedLesson.Id = lesson.Id;
            updatedLesson.LessonName = lesson.LessonName;
            updatedLesson.SectionId = lesson.SectionId;
            updatedLesson.ReadDuration = lesson.ReadDuration;
            updatedLesson.LessonDescriptions = _unitOfWork.LessonDescriptions.GetLessonDescription(lesson.Id, langId);
            updatedLesson.AddTime = lesson.AddTime;
            updatedLesson.ImageURL = (_unitOfWork.Images.GetImage(x => x.Id == lesson.ImageId) == null) ? "" : _unitOfWork.Images.GetImage(x => x.Id == lesson.ImageId).ImageURL;
            updatedLesson.Questions = _unitOfWork.LessonQuestionsDetails.GetLessonQuestionsWithDetails(lesson.Id, langId).Questions;

            return updatedLesson;
        }
    }
}
