using DAL.IRepositories.IFXGame;
using System;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWorkIFXGame : IDisposable
    {
        IUserInfoRepository UserInfo { get; }
        IUserAccountRepository UserAccount { get; }
        IUserTokenRepository UserToken { get; }
    }
}
