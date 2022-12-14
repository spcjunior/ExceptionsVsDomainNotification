namespace ExceptionsVsDomainNotification.NotificationApi.Models
{
    public record UserRequest(        
        string Email,
        string Password);

    public record UserResponse(
        string Token,
        string Email);
}
