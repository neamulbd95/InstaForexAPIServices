using DAL.UnitOfWork;
using InstaForexAPIServices.Response;
using InstaForexAPIServices.Response.IFXGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace InstaForexAPIServices.Controllers.IFXGame
{
    public class UserInfoController : ApiController
    {
        private readonly IUnitOfWorkIFXGame _unitOfWork;
        IUnityContainer container = new UnityContainer();

        public UserInfoController(IUnitOfWorkIFXGame unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("api/IFXGame/v1/CheckNickName")]
        public  GeneralResponse<ErroMessage> CheckName(string nickName)
        {
            var result = container.Resolve<GeneralResponse<ErroMessage>>();
            var message = container.Resolve<ErroMessage>();

            if (string.IsNullOrEmpty(nickName))
            {
                result.ResponseCode = HttpStatusCode.BadRequest;
                result.ResponseMessage = "Request is wrong";
                result.Result = null;
                return result;
            }
            else
            {
                var user = _unitOfWork.UserInfo.GetSingle(x => x.NickName.ToUpper() == nickName.ToUpper());

                if(user == null)
                {
                    message.ErrorStatus = false;
                    message.Message = "This nick name is available";

                    result.ResponseCode = HttpStatusCode.OK;
                    result.ResponseMessage = "Request is okay";
                    result.Result = (IEnumerable<ErroMessage>)message;
                    return result;
                }

                else
                {
                    message.ErrorStatus = true;
                    message.Message = "Such nick name has been already existed";

                    result.ResponseCode = HttpStatusCode.OK;
                    result.ResponseMessage = "Request is okay";
                    result.Result = (IEnumerable<ErroMessage>)message;
                    return result;
                }
            }
        }
    }
}
