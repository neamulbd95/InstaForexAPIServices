using DAL.Domain.CryptoLearn;
using DAL.IRepositories.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepositories.CryptoLearn
{
    public interface ILessonImageRepository : IRepository<Image>
    {
        Image GetImage(Expression<Func<Image, bool>> condition);
    }
}
