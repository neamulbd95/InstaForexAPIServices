using DAL.UnitOfWork;
using InstaForexAPIServices.Response;
using InstaForexAPIServices.Response.CryptoLearn;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Unity;

namespace InstaForexAPIServices.Controllers
{
    public class LessonLikeViewController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        IUnityContainer container = new UnityContainer();

        public LessonLikeViewController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("api/CryptoLearn/v1/BooksLikesAndViews")]
        public GeneralResponse<LessonLikeViewResponse> GetLikesAndViews(int sectionId)
        {
            var lessons = _unitOfWork.Lessons.GetByCondition(x => x.SectionId == sectionId);

            var likesAndViews = container.Resolve<List<LessonLikeViewResponse>>();

            foreach(var les in lessons)
            {
                var likeView = container.Resolve<LessonLikeViewResponse>();

                likeView.LessonId = les.Id;
                var lessonLikes = _unitOfWork.Likes.GetByCondition(x => x.LessonId == les.Id && x.CheckLike == true);

                if (lessonLikes == null)
                    likeView.TotalLikes = 0;
                else
                    likeView.TotalLikes = _unitOfWork.Likes.GetTotalLike(les.Id);

                likeView.TotalViews = _unitOfWork.Views.GetLessonTotalViews(les.Id);

                likesAndViews.Add(likeView);
            }

            var result = container.Resolve<GeneralResponse<LessonLikeViewResponse>>();
            result.ResponseCode = HttpStatusCode.OK;
            result.ResponseMessage = "Input is okay.";
            result.Result = likesAndViews;

            return result;
        }
    }
}
