using DAL.IRepositories.CryptoLearn;
using System;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDeviceRepository Devices { get; }
        ILanguageRepository Languages { get; }
        ILessonRepository Lessons { get; }
        ILessonDescriptionRepository LessonDescriptions { get; }
        ILessonQuestionAndOptionRepository LessonQuestionsDetails { get; }
        ISectionRepository Sections { get; }

        int Complete();
    }
}
