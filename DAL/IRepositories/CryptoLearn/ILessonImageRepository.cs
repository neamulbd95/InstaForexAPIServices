using DAL.Domain.CryptoLearn;
using DAL.IRepositories.General;
using System;
using System.Linq.Expressions;

namespace DAL.IRepositories.CryptoLearn
{
    public interface ILessonImageRepository : IRepository<Image>
    {
        Image GetImage(Expression<Func<Image, bool>> condition);
    }
}
