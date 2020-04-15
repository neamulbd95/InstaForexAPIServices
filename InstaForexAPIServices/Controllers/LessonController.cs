using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public IHttpActionResult GetLessonById(int lessonId)
        {
            if(lessonId < 1)
            {
                return Content(HttpStatusCode.BadRequest, "ID can not be less that 1");
            }
            var result = _unitofwork.Lessons.GetLessonWithBook(lessonId);
            return Ok(result);
        }
    }
}
