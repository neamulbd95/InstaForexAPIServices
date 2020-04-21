using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Domain.IFXGame
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string NickName { get; set; }
        public bool ActiveStatus { get; set; }

    }
}
