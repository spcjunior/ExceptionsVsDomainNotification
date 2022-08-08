namespace ExceptionsVsDomainNotification.ExceptionApi.Models
{
    public class User
    {
        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
