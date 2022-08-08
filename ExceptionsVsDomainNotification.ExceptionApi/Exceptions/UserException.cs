using System.Runtime.Serialization;

namespace ExceptionsVsDomainNotification.ExceptionApi.Exceptions
{
    [Serializable]
    public class UserException : DomainException<UserExceptionCoreError>
    {
        public UserException(UserExceptionCoreError empresaCoreError)
        {
            AddError(empresaCoreError);
        }

        protected UserException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override string Key => "UserException";
    }

    public class UserExceptionCoreError : DomainError
    {
        public static UserExceptionCoreError InvalidEmailAddress =>
            new("InvalidEmailAddress", "Enter with a valid email.");

        public static UserExceptionCoreError InvalidPassword =>
            new("InvalidPassword", "Enter with a valid password.");

        protected UserExceptionCoreError(string key, string message) : base(key, message) { }
    }
}
