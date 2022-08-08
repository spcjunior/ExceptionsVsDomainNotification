namespace ExceptionsVsDomainNotification.NotificationApi.Models
{
    public struct InvalidPassword : IValidationError
    {
        private const string ErroMessage = "Invalid password. Enter at least 6 numbers.";
        public string Message { get; }

        public InvalidPassword()
        {
            Message = ErroMessage;
        }
    }
}
