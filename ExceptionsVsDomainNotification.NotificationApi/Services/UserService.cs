using ExceptionsVsDomainNotification.NotificationApi.Models;
using OneOf;
using System.Text.RegularExpressions;

namespace ExceptionsVsDomainNotification.NotificationApi.Services
{
    public interface IUserService
    {
        OneOf<UserResponse, InvalidEmailAddress, InvalidPassword> Login(UserRequest userRequest);
    }

    public class UserService : IUserService
    {
        private static readonly Regex EmailValidationRegex = new(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$");

        public OneOf<UserResponse, InvalidEmailAddress, InvalidPassword> Login(UserRequest userRequest)
        {
            if (!IsValidEmail(userRequest.Email))
            {
                return new InvalidEmailAddress(userRequest.Email);
            }

            if (!IsValidPassword(userRequest.Password))
            {
                return new InvalidPassword();
            }

            var newUser = new User(userRequest.Email, userRequest.Password);

            //Check Database

            return new UserResponse(Guid.NewGuid().ToString(), newUser.Email);
        }

        public static bool IsValidEmail(string email)
        {
            return EmailValidationRegex.IsMatch(email);
        }

        public static bool IsValidPassword(string password)
        {
            return password.Length >= 6 && int.TryParse(password, out int value);
        }
    }
}
