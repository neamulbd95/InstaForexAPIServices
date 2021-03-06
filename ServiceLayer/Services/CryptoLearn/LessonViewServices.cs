﻿using DAL.Domain.CryptoLearn;
using System;
using Unity;

namespace ServiceLayer.Services.CryptoLearn
{
    public static class LessonViewServices
    {
        public static LessonView AddView(int lessonId, int deviceId)
        {
            IUnityContainer container = new UnityContainer();
            var view  = container.Resolve<LessonView>();

            view.LessonId = lessonId;
            view.DeviceId = deviceId;
            view.LastView = DateTime.Now;
            view.TotalView = 1;
            return view;
        }
    }
}
