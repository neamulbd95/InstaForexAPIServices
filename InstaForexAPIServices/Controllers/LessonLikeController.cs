﻿using DAL.Domain.CryptoLearn;
using DAL.UnitOfWork;
using InstaForexAPIServices.RequestInputClass.CryptoLearn;
using InstaForexAPIServices.Response;
using ServiceLayer.Services.CryptoLearn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace InstaForexAPIServices.Controllers
{
    public class LessonLikeController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        IUnityContainer container = new UnityContainer();

        public LessonLikeController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("api/CryptoLearn/v1/AddLike")]
        public IHttpActionResult AddingLike(LikeViewRequest input)
        {
            Device device = _unitOfWork.Devices.GetSingle(x => x.DeviceToken == input.DeviceToken);
            LessonLike likes = _unitOfWork.Likes.GetSingle( x => x.LessonId == input.LessonId && x.DeviceId == device.Id);

            if(likes == null)
            {
                var like = LessonLikeService.AddLike(input.LessonId, device.Id);
                _unitOfWork.Likes.Add(like);
                _unitOfWork.Complete();
            }

            else
            {
                if (likes.CheckLike == true)
                    likes.CheckLike = false;

                else if (likes.CheckLike == false)
                    likes.CheckLike = true;

                _unitOfWork.Complete();
            }
            return Ok();
        }

        [HttpGet]
        [Route("api/CryptoLearn/v1/LessonTotalLike")]
        public GeneralResponse<int> GetLessonTotalLike(int lessonId)
        {
            var result = container.Resolve<GeneralResponse<int>>();

            IList<int> totalLike = new List<int>();
            totalLike.Add(_unitOfWork.Likes.GetTotalLike(lessonId));

            result.ResponseCode = HttpStatusCode.OK;
            result.ResponseMessage = "Requst input is okay";
            result.Result = totalLike;

            return result;
        }
    }
}
