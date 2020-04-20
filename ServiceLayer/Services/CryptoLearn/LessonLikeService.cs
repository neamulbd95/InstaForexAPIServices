using DAL.Domain.CryptoLearn;
using Unity;

namespace ServiceLayer.Services.CryptoLearn
{
    public static class LessonLikeService
    {
        public static LessonLike AddLike(int lessonId, int deviceId)
        {
            IUnityContainer container = new UnityContainer();
            var likes = container.Resolve<LessonLike>();

            likes.LessonId = lessonId;
            likes.DeviceId = deviceId;
            likes.CheckLike = true;
            return likes;
        }
    }
}
