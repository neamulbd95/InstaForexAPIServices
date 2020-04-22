using DAL.IRepositories.IFXGame;
using System;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWorkIFXGame : IDisposable
    {
        IUserInfoRepository UserInfo { get; }
        IUserTokenRepository UserToken { get; }

        int Complete();
    }
}
