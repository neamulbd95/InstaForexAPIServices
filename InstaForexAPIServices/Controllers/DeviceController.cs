using DAL.Domain.CryptoLearn;
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
    public class DeviceController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        IUnityContainer container = new UnityContainer();

        public DeviceController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("api/CryptoLearn/v1/GetDevices")]
        public GeneralResponse<Device> GetDevice()
        {
            var result = container.Resolve<GeneralResponse<Device>>();

            result.ResponseCode = HttpStatusCode.OK;
            result.ResponseMessage = "Request is okay";
            result.Result = _unitOfWork.Devices.GetAll();
            return result;
        }

        [HttpGet]
        [Route("api/CryptoLearn/v1/GetDeviceById")]
        public GeneralResponse<Device> GetDeviceId(int id)
        {
            var result = container.Resolve<GeneralResponse<Device>>();

            result.ResponseCode = HttpStatusCode.OK;
            result.ResponseMessage = "Request is okay";
            result.Result = (IEnumerable<Device>)_unitOfWork.Devices.GetByID(id);
            return result;
        }

        [HttpPost]
        [Route("api/CryptoLearn/v1/AddDevice")]
        public GeneralResponse<Device> AddDeivce(Device device)
        {
            var result = container.Resolve<GeneralResponse<Device>>();

            if (!ModelState.IsValid)
            {
                result.ResponseCode = HttpStatusCode.BadRequest;
                result.ResponseMessage = "Invalid Request";
                result.Result = null;
                return result;
            }

            var dev = _unitOfWork.Devices.GetSingle(x => x.DeviceToken == device.DeviceToken);
            if(dev == null)
            {
                _unitOfWork.Devices.Add(dev);
                _unitOfWork.Complete();

                result.ResponseCode = HttpStatusCode.OK;
                result.ResponseMessage = "Request is okay";
                result.Result = (IEnumerable<Device>)_unitOfWork.Devices.GetByID(dev.Id);
                return result;
            }     
            else
            {
                result.ResponseCode = HttpStatusCode.Conflict;
                result.ResponseMessage = "This device has been already registered";
                result.Result = (IEnumerable<Device>)_unitOfWork.Devices.GetByID(dev.Id);
                return result;
            }
        }
    }
}
