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
    }
}
