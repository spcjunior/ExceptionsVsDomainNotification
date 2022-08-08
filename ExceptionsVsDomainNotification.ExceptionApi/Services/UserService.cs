using ExceptionsVsDomainNotification.ExceptionApi.Exceptions;
using ExceptionsVsDomainNotification.ExceptionApi.Models;
using System.Text.RegularExpressions;

namespace ExceptionsVsDomainNotification.ExceptionApi.Services
{
    public interface IUserService
    {
        UserResponse Login(UserRequest userRequest);
    }

    public class UserService : IUserService
    {
        private static readonly Regex EmailValidationRegex = new(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$");

        public UserResponse Login(UserRequest userRequest)
        {
            if (!IsValidEmail(userRequest.Email))
            {
                throw new UserException(UserExceptionCoreError.InvalidEmailAddress);
            }

            if (!IsValidPassword(userRequest.Password))
            {
                throw new UserException(UserExceptionCoreError.InvalidPassword);
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
