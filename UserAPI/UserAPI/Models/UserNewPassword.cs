namespace UserAPI.Models
{
    public class UserNewPassword
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }

        public string Token { get; set; }

        public UserNewPassword()
        {

        }
    }
}
