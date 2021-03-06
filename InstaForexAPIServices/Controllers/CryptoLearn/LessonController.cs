﻿using DAL.ComplexTypeClasses.CryptoLearn;
using DAL.UnitOfWork;
using InstaForexAPIServices.Response;
using System.Net;
using System.Web.Http;
using Unity;

namespace InstaForexAPIServices.Controllers.CryptoLearn
{
    public class LessonController : ApiController 
    {
        private readonly IUnitOfWorkCryptoLearn _unitofwork;
        IUnityContainer container = new UnityContainer();

        public LessonController(IUnitOfWorkCryptoLearn unitofwork)
        {
            this._unitofwork = unitofwork;
        }

        [HttpGet]
        [Route("api/CryptoLearn/v1/LessonByID")]
        public GeneralResponse<LessonDetails> GetLessonById(int lessonId)
        {           
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


        [HttpGet]
        [Route("api/CryptoLearn/v1/LessonByBook")]
        public IHttpActionResult GetLessonByBook(int bookId, string lang)
        {
            if (bookId < 1 || string.IsNullOrEmpty(lang))
            {
                var result = container.Resolve<GeneralResponse<LessonDetails>>();
                result.ResponseCode = HttpStatusCode.BadRequest;
                result.ResponseMessage = "Invaild Input.";
                result.Result = null;

                return Content(HttpStatusCode.BadRequest, result);
            }

            int langId = _unitofwork.Languages.GetLanguageId(x => x.LanguageName.ToUpper() == lang.ToUpper()).Id;

            if (bookId != 1 || bookId != 3)
            {
                var result = container.Resolve<GeneralResponse<LessonDetails>>();
                result.ResponseCode = HttpStatusCode.OK;
                result.ResponseMessage = "Request Input is okay.";
                result.Result = _unitofwork.Lessons.GetLessonsByBookAndLanguage(bookId, langId);

                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                var result = container.Resolve<GeneralResponse<LessonDetailsWithImage>>();
                result.ResponseCode = HttpStatusCode.OK;
                result.ResponseMessage = "Request Input is okay.";
                result.Result = _unitofwork.Lessons.GetLessonsWithImageByBookAndLanguage(bookId, langId);

                return Content(HttpStatusCode.OK, result);
            }
        }
    }
}
