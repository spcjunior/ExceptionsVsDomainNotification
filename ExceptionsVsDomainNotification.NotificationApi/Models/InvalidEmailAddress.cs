namespace ExceptionsVsDomainNotification.NotificationApi.Models
{
    public readonly struct InvalidEmailAddress : IValidationError
    {
        private const string ErroMessage = "Enter with a valid email. '{0}' is not a valid email.";
        public string Message { get; }

        public InvalidEmailAddress(string emailAddress)
        {
            Message = string.Format(ErroMessage, emailAddress);
        }
    }
}
