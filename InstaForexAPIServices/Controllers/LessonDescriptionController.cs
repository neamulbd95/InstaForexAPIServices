using DAL.ComplexTypeClasses.CryptoLearn;
using DAL.UnitOfWork;
using InstaForexAPIServices.Response;
using System.Net;
using System.Web.Http;
using Unity;

namespace InstaForexAPIServices.Controllers
{
    public class LessonDescriptionController : ApiController
    {
        private readonly IUnitOfWorkCryptoLearn _unitofwork;
        IUnityContainer container = new UnityContainer();

        public LessonDescriptionController(IUnitOfWorkCryptoLearn unitOfWork)
        {
            this._unitofwork = unitOfWork;
        }

        [HttpGet]
        [Route("api/CryptoLearn/v1/LessonDescription")]
        public GeneralResponse<LessonDescriptionsDetail> GetLessonDescription(int lessonId, string lang)
        {
            var result = container.Resolve<GeneralResponse<LessonDescriptionsDetail>>();
            if (lessonId < 1 || string.IsNullOrEmpty(lang))
            {                
                result.ResponseCode = HttpStatusCode.BadRequest;
                result.ResponseMessage = "ID can not be less than 1.";
                result.Result = null;

                return result;
            }
            else
            {
                int langId = _unitofwork.Languages.GetLanguageId(x => x.LanguageName.ToUpper() == lang.ToUpper()).Id;

                result.ResponseCode = HttpStatusCode.OK;
                result.ResponseMessage = "Request input is okay";
                result.Result = _unitofwork.LessonDescriptions.GetLessonDescription(lessonId,langId);

                return result;
            }
        }
    }
}
