using DAL.Domain.CryptoLearn;
using DAL.UnitOfWork;
using InstaForexAPIServices.ENum;
using InstaForexAPIServices.RequestInputClass.CryptoLearn;
using InstaForexAPIServices.Response;
using InstaForexAPIServices.Response.CryptoLearn;
using ServiceLayer.CustomClasses.CryptoLearn;
using ServiceLayer.Services.CryptoLearn;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Unity;

namespace InstaForexAPIServices.Controllers
{
    public class LessonUpdateController : ApiController
    {
        private readonly IUnitOfWorkCryptoLearn _unitOfWork;
        IUnityContainer container = new UnityContainer();

        public LessonUpdateController(IUnitOfWorkCryptoLearn unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("api/CryptoLearn/v1/CheckUpdate")]
        public GeneralResponse<LessonUpdateStatus> CheckUpdate(LessonUpdateCheck check)
        {
            var result = container.Resolve<GeneralResponse<LessonUpdateStatus>>();
            if (check.ClientTimeStamp == 0)
            {
                result.ResponseCode = HttpStatusCode.BadRequest;
                result.ResponseMessage = "Invaild Input.";
                result.Result = null;
            }

            int langId = _unitOfWork.Languages.GetLanguageId(x => x.LanguageName.ToUpper() == check.Language.ToUpper()).Id;
            int lastUpdate = _unitOfWork.Lessons.MaxAddedTime();
            int lessonCount = _unitOfWork.Lessons.LessonCount(langId);

            var update = container.Resolve<LessonUpdateStatus>();

            if(lastUpdate > check.ClientTimeStamp)
            {
                update.Update = 1;
                if(lessonCount > check.LessonCount)
                {
                    update.UpdateCode = LessonUpdateENum.Add;
                    update.UpdateStatus = "New lesson(s) have been added.";
                }
                else
                {
                    update.UpdateCode = LessonUpdateENum.Update;
                    update.UpdateStatus = "Existing lesson(s) have been updated.";
                }
            }

            result.ResponseCode = HttpStatusCode.OK;
            result.ResponseMessage = "Request input is okay.";
            result.Result = (IEnumerable<LessonUpdateStatus>)update;

            return result;
        }

        [HttpPost]
        [Route("api/CryptoLearn/v1/AddLesson")]
        public GeneralResponse<UpdatedLesson> AddLesson(LessonUpdateCheck checkUpdate)
        {
            var result = container.Resolve<GeneralResponse<UpdatedLesson>>();
            if (checkUpdate.ClientTimeStamp == 0)
            {
                result.ResponseCode = HttpStatusCode.BadRequest;
                result.ResponseMessage = "Invaild Input.";
                result.Result = null;

                return result;
            }

            int langId = _unitOfWork.Languages.GetLanguageId(x => x.LanguageName.ToUpper() == checkUpdate.Language.ToUpper()).Id;

            if(langId == 0)
            {
                result.ResponseCode = HttpStatusCode.BadRequest;
                result.ResponseMessage = "Invaild Input.";
                result.Result = null;
            }

            IList<Lesson> newLessons = _unitOfWork.Lessons.GetByCondition(x=> x.AddTime > checkUpdate.ClientTimeStamp).ToList();

            List<LessonUpdateDetails> newLessonsDetails = container.Resolve<List<LessonUpdateDetails>>();

            foreach(var item in newLessons)
            {
                var newLessonDetails = LessonDetailsService.GetLessonDetails(_unitOfWork,item,langId);
                newLessonsDetails.Add(newLessonDetails);
            }

            var updatedResponse = container.Resolve<UpdatedLesson>();
            updatedResponse.NewLesson = newLessonsDetails;
            updatedResponse.NewUpdatedTimeStamp = _unitOfWork.Lessons.MaxAddedTime();

            result.ResponseCode = HttpStatusCode.OK;
            result.ResponseMessage = "Request input is okay.";
            result.Result = (IEnumerable<UpdatedLesson>)updatedResponse;

            return result;
        }


        [HttpPost]
        [Route("api/CryptoLearn/v1/UpdateLesson")]
        public GeneralResponse<UpdatedLesson> UpdateLesson(LessonUpdateCheck checkUpdate)
        {
            var result = container.Resolve<GeneralResponse<UpdatedLesson>>();
            if (checkUpdate.ClientTimeStamp == 0)
            {
                result.ResponseCode = HttpStatusCode.BadRequest;
                result.ResponseMessage = "Invaild Input.";
                result.Result = null;

                return result;
            }

            int langId = _unitOfWork.Languages.GetLanguageId(x => x.LanguageName.ToUpper() == checkUpdate.Language.ToUpper()).Id;

            if (langId == 0)
            {
                result.ResponseCode = HttpStatusCode.BadRequest;
                result.ResponseMessage = "Invaild Input.";
                result.Result = null;
            }

            IList<Lesson> newLessons = _unitOfWork.Lessons.GetByCondition(x => x.AddTime > checkUpdate.ClientTimeStamp).ToList();

            List<LessonUpdateDetails> newLessonsDetails = container.Resolve<List<LessonUpdateDetails>>();

            foreach (var item in newLessons)
            {
                var newLessonDetails = LessonDetailsService.GetLessonDetails(_unitOfWork, item, langId);
                newLessonsDetails.Add(newLessonDetails);
            }

            var updatedResponse = container.Resolve<UpdatedLesson>();
            updatedResponse.NewLesson = newLessonsDetails;
            updatedResponse.NewUpdatedTimeStamp = _unitOfWork.Lessons.MaxAddedTime();

            result.ResponseCode = HttpStatusCode.OK;
            result.ResponseMessage = "Request input is okay.";
            result.Result = (IEnumerable<UpdatedLesson>)updatedResponse;

            return result;
        }
    }
}
