using DAL.Domain.IFXGame;
using DAL.IRepositories.General;

namespace DAL.IRepositories.IFXGame
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        void UpdateUserAccount(UserAccount account);
    }
}
