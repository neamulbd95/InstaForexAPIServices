﻿using DAL.IRepositories.CryptoLearn;
using System;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWorkCryptoLearn : IDisposable
    {
        IDeviceRepository Devices { get; }
        ILanguageRepository Languages { get; }
        ILessonRepository Lessons { get; }
        ILessonDescriptionRepository LessonDescriptions { get; }
        ILessonQuestionAndOptionRepository LessonQuestionsDetails { get; }
        ISectionRepository Sections { get; }
        ILessonImageRepository Images { get; }
        ILessonViewRepository Views { get; }
        ILessonLikeRepository Likes { get; }

        int Complete();
    }
}
