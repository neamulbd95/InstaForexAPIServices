namespace DAL.Domain.IFXGame
{
    public class UserToken
    {
        public int Id { get; set; }
        public int UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }
        public string Token { get; set; }
    }
}
