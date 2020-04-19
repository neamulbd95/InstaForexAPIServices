﻿using DAL.UnitOfWork;
using InstaForexAPIServices.ENum;
using InstaForexAPIServices.RequestInputClass.CryptoLearn;
using InstaForexAPIServices.Response;
using InstaForexAPIServices.Response.CryptoLearn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace InstaForexAPIServices.Controllers
{
    public class LessonUpdateController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        IUnityContainer container = new UnityContainer();

        public LessonUpdateController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public GeneralResponse<LessonUpdateStatus> CheckUpdate(LessonUpdateCheck check)
        {
            var result = container.Resolve<GeneralResponse<LessonUpdateStatus>>();
            if (check.ClientTimeStamp == 0)
            {
                result.ResponseCode = HttpStatusCode.BadRequest;
                result.ResponseMessage = "Invaild Input.";
                result.Result = null;
            }

            int langId = _unitOfWork.Languages.GetLanguageId(x => x.LanguageName.ToUpper() == check.Language.ToUpper()).Id;
            int lastUpdate = _unitOfWork.Lessons.MaxAddedTime();
            int lessonCount = _unitOfWork.Lessons.LessonCount(langId);

            var update = container.Resolve<LessonUpdateStatus>();

            if(lastUpdate > check.ClientTimeStamp)
            {
                update.Update = 1;
                if(lessonCount > check.LessonCount)
                {
                    update.UpdateCode = LessonUpdateENum.Add;
                    update.UpdateStatus = "New lesson(s) have been added.";
                }
                else
                {
                    update.UpdateCode = LessonUpdateENum.Update;
                    update.UpdateStatus = "Existing lesson(s) have been updated.";
                }
            }

            result.ResponseCode = HttpStatusCode.OK;
            result.ResponseMessage = "Request input is okay.";
            result.Result = (IEnumerable<LessonUpdateStatus>)update;

            return result;
        }
    }
}