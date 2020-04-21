using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domain.IFXGame
{
    public class UserAccount
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public UserInfo UserInfo { get; set; }

        public double CurrentBalance { get; set; }
        public double BalanceForDay { get; set; }
        public int NumberProfitDeals { get; set; }
    }
}
