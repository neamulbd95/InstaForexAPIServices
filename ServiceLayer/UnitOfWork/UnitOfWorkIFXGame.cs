using DAL.Context.IFXGame;
using DAL.IRepositories.IFXGame;
using DAL.UnitOfWork;
using ServiceLayer.Repository.IFXGame;

namespace ServiceLayer.UnitOfWork
{
    public class UnitOfWorkIFXGame : IUnitOfWorkIFXGame
    {
        private readonly IFXGameContext context;

        public UnitOfWorkIFXGame(IFXGameContext _context)
        {
            this.context = _context;
            UserInfo = new UserInfoRepository(context);
            UserToken = new UserTokenRepository(context);
        }

        public IUserInfoRepository UserInfo { get; private set; }
        public IUserTokenRepository UserToken { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
