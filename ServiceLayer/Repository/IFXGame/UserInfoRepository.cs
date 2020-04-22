using DAL.Context.IFXGame;
using DAL.Domain.IFXGame;
using DAL.IRepositories.IFXGame;
using ServiceLayer.Repository.General;

namespace ServiceLayer.Repository.IFXGame
{
    public class UserInfoRepository : Repository<UserInfo> , IUserInfoRepository
    {
        public UserInfoRepository(IFXGameContext context) : base(context)
        {

        }

        public IFXGameContext IFXGameContext
        {
            get { return Context as IFXGameContext; }
        }

        public void UpdateUserAccountAndToken(UserInfo User, string newAccountNumber, string newToken)
        {
            User.AccountNumber = newAccountNumber;
            User.UserToken.Token = newToken;
        }
    }
}
