namespace DAL.Domain.IFXGame
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string NickName { get; set; }
        public bool ActiveStatus { get; set; }

        public UserAccount UserAccount { get; set; }
        public UserToken UserToken { get; set; }

    }
}
