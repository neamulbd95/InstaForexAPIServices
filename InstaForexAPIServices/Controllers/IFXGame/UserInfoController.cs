using DAL.Domain.IFXGame;
using DAL.UnitOfWork;
using InstaForexAPIServices.RequestInputClass.IFXGame;
using InstaForexAPIServices.Response;
using InstaForexAPIServices.Response.IFXGame;
using ServiceLayer.TokenGenerator;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
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

        
        [HttpPost]
        [Route("api/IFXGame/v1/AddUser")]
        public GeneralResponse<ResponseUserInfo> AddingUser(UserInfoRequest u)
        {
            var result = container.Resolve<GeneralResponse<ResponseUserInfo>>();
            if (!ModelState.IsValid)
            {
                result.ResponseCode = HttpStatusCode.BadRequest;
                result.ResponseMessage = "Request is wrong";
                result.Result = null;
                return result;
            }

            try
            {
                var user = _unitOfWork.UserInfo.GetSingle(x => x.NickName.ToUpper() == u.NickName.ToUpper());
                var message = container.Resolve<ErroMessage>();

                if (user != null)
                {
                    result.ResponseCode = HttpStatusCode.Conflict;
                    result.ResponseMessage = "Request is okay and This nick name is already existed.";
                    result.Result = null;
                    return result;
                }

                user.NickName = u.NickName;
                user.AccountNumber = u.AccountNumber;
                user.ActiveStatus = true;

                _unitOfWork.UserInfo.Add(user);
                _unitOfWork.Complete();

                var token = container.Resolve<UserToken>();

                token.UserInfoId = user.Id;
                token.Token = String.Concat(TokenGenerator.Generate(32), user.NickName);

                _unitOfWork.UserToken.Add(token);
                _unitOfWork.Complete();

                var UserResponse = container.Resolve<ResponseUserInfo>();

                UserResponse.Id = user.Id;
                UserResponse.AccountNumber = user.AccountNumber;
                UserResponse.NickName = user.NickName;
                UserResponse.ActivityStatus = user.ActiveStatus;
                UserResponse.UserToken = token.Token;

                result.ResponseCode = HttpStatusCode.OK;
                result.ResponseMessage = "User has been added";
                result.Result = (IEnumerable<ResponseUserInfo>)UserResponse;
                return result;
            }
            catch
            {
                result.ResponseCode = HttpStatusCode.BadRequest;
                result.ResponseMessage = "Something went wrong";
                result.Result = null;
                return result;
            }
        }


        [HttpPut]
        [Route("api/IFXGame/v1/UpdateUserAccountNumber")]
        public GeneralResponse<ResponseUserInfo> UpdateAccNumber(string userToken, UserInfoRequest userInfo)
        {
            var result = container.Resolve<GeneralResponse<ResponseUserInfo>>();
            if (!ModelState.IsValid)
            {
                result.ResponseCode = HttpStatusCode.BadRequest;
                result.ResponseMessage = "Request is wrong";
                result.Result = null;
                return result;
            }

            try
            {
                var token = _unitOfWork.UserToken.GetSingle(x=> x.Token == userToken);
                if(token == null)
                {
                    result.ResponseCode = HttpStatusCode.NotFound;
                    result.ResponseMessage = "Invalid User Token";
                    result.Result = null;
                    return result;
                }

                var user = _unitOfWork.UserInfo.GetSingle(x => x.NickName.ToUpper() == userInfo.NickName.ToUpper() && x.Id == token.UserInfoId);
                if(user == null)
                {
                    result.ResponseCode = HttpStatusCode.NotFound;
                    result.ResponseMessage = "Invalid User";
                    result.Result = null;
                    return result;
                }

                user.AccountNumber = userInfo.AccountNumber;
                token.Token = String.Concat(TokenGenerator.Generate(32), user.NickName);

                _unitOfWork.Complete();

                var UserResponse = container.Resolve<ResponseUserInfo>();

                UserResponse.Id = user.Id;
                UserResponse.AccountNumber = user.AccountNumber;
                UserResponse.NickName = user.NickName;
                UserResponse.ActivityStatus = user.ActiveStatus;
                UserResponse.UserToken = token.Token;

                result.ResponseCode = HttpStatusCode.OK;
                result.ResponseMessage = "User has been updated";
                result.Result = (IEnumerable<ResponseUserInfo>)UserResponse;
                return result;
            }
            catch
            {
                result.ResponseCode = HttpStatusCode.BadRequest;
                result.ResponseMessage = "Something went wrong";
                result.Result = null;
                return result;
            }
        }

    }
}
