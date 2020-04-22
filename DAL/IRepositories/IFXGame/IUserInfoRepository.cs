using DAL.Domain.IFXGame;
using DAL.IRepositories.General;

namespace DAL.IRepositories.IFXGame
{
    public interface IUserInfoRepository : IRepository<UserInfo>
    {
        void UpdateUserAccountAndToken(UserInfo User, string newAccountNumber, string newToken);
    }
}
