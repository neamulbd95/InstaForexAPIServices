using DAL.ComplexTypeClasses.CryptoLearn;
using DAL.UnitOfWork;
using InstaForexAPIServices.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace InstaForexAPIServices.Controllers
{
    public class LessonController : ApiController
    {
        private readonly IUnitOfWork _unitofwork;

        public LessonController(IUnitOfWork unitofwork)
        {
            this._unitofwork = unitofwork;
        }

        [HttpGet]
        public GeneralResponse<LessonDetails> GetLessonById(int lessonId)
        {
            IUnityContainer container = new UnityContainer();
            if (lessonId < 1)
            {
                var result = container.Resolve<GeneralResponse<LessonDetails>>();
                result.ResponseCode = HttpStatusCode.BadRequest;
                result.ResponseMessage = "ID can not be less than 1.";
                result.Result = null;

                return result;
            }
            else
            {
                var result = container.Resolve<GeneralResponse<LessonDetails>>();
                result.ResponseCode = HttpStatusCode.OK;
                result.ResponseMessage = "Request is okay";
                result.Result = _unitofwork.Lessons.GetLessonWithBook(lessonId);

                return result;
            }
        }
    }
}
