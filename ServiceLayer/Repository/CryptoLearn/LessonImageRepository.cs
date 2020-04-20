using DAL.Context.CryptoLearn;
using DAL.Domain.CryptoLearn;
using DAL.IRepositories.CryptoLearn;
using ServiceLayer.Repository.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Repository.CryptoLearn
{
    public class LessonImageRepository : Repository<Image>, ILessonImageRepository
    {
        public LessonImageRepository(CryptoLearnContext context) : base(context)
        {

        }

        public CryptoLearnContext CryptoLearnContext
        {
            get { return Context as CryptoLearnContext; }
        }

        public Image GetImage(Expression<Func<Image, bool>> condition)
        {
            return CryptoLearnContext.Images.SingleOrDefault(condition);
        }
    }
}
