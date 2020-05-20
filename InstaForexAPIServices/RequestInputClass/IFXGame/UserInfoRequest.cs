using System.ComponentModel.DataAnnotations;

namespace InstaForexAPIServices.RequestInputClass.IFXGame
{
    public class UserInfoRequest
    {
        [Required]
        public string NickName { get; set; }
        [Required]
        public string AccountNumber { get; set; }
    }
}