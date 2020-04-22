using DAL.Context.IFXGame;
using DAL.Domain.IFXGame;
using DAL.IRepositories.IFXGame;
using ServiceLayer.Repository.General;

namespace ServiceLayer.Repository.IFXGame
{
    public class UserTokenRepository : Repository<UserToken> , IUserTokenRepository
    {
        public UserTokenRepository(IFXGameContext context) : base(context)
        {

        }

        public IFXGameContext IFXGameContext
        {
            get { return Context as IFXGameContext; }
        }
    }
}
