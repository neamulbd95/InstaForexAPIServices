using DAL.Domain.CryptoLearn;
using DAL.UnitOfWork;
using InstaForexAPIServices.RequestInputClass.CryptoLearn;
using InstaForexAPIServices.Response;
using ServiceLayer.Services.CryptoLearn;
using System;
using System.Web.Http;
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
    }
}
