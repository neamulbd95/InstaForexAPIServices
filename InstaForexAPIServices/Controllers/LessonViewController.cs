using DAL.Domain.CryptoLearn;
using DAL.UnitOfWork;
using InstaForexAPIServices.RequestInputClass.CryptoLearn;
using InstaForexAPIServices.Response;
using ServiceLayer.Services.CryptoLearn;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Net;
using Unity;

namespace InstaForexAPIServices.Controllers
{
    public class LessonViewController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        IUnityContainer container = new UnityContainer();

        public LessonViewController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("api/CryptoLearn/v1/AddView")]
        public IHttpActionResult AddView(LikeViewRequest userInput)
        {
            Device device = _unitOfWork.Devices.GetSingle(x=>x.DeviceToken == userInput.DeviceToken);

            LessonView view = _unitOfWork.Views.GetSingle(x=> x.LessonId == userInput.LessonId && x.DeviceId == device.Id);
            
            if(view == null)
            {
                var addingView = LessonViewServices.AddView(userInput.LessonId, device.Id);
                _unitOfWork.Views.Add(addingView);
                _unitOfWork.Complete();
            }
            else
            {
                DateTime recentTime = DateTime.Now;
                DateTime lastTime = view.LastView;
                
                if(recentTime.Subtract(lastTime).TotalMinutes > 120)
                {
                    view.LastView = recentTime;
                    view.TotalView = view.TotalView + 1;

                    _unitOfWork.Complete();
                }
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/CryptoLearn/v1/LessonTotalView")]
        public GeneralResponse<int> GetLessonTotalView(int lessonId)
        {
            var result = container.Resolve<GeneralResponse<int>>();

            IList<int> totalView = new List<int>();
            totalView.Add(_unitOfWork.Views.GetLessonTotalViews(lessonId));

            result.ResponseCode = HttpStatusCode.OK;
            result.ResponseMessage = "Requst input is okay";
            result.Result = totalView;

            return result;
        }

        [HttpGet]
        [Route("api/CryptoLearn/v1/BookTotalView")]
        public GeneralResponse<int> GetSectionTotalView(int sectionId)
        {
            int totalView = 0;
            var result = container.Resolve<GeneralResponse<int>>();

            var lessons = _unitOfWork.Lessons.GetByCondition(x => x.SectionId == sectionId);

            foreach(var les in lessons)
            {
                totalView += _unitOfWork.Views.GetLessonTotalViews(les.Id);
            }
            IList<int> View = new List<int>();
            View.Add(totalView);

            result.ResponseCode = HttpStatusCode.OK;
            result.ResponseMessage = "Requst input is okay";
            result.Result = View;
            return result;
        }
    }
}
