using ExceptionsVsDomainNotification.NotificationApi.Models;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace ExceptionsVsDomainNotification.NotificationApi.Extensions
{
    public static class ResponseExtensions
    {
        public static IActionResult MatchResponse<T1, T2>(this OneOf<T1, T2> oneOf)
        {
            return oneOf.Match(
                MatchPotentialValidationErrorResponse,
                MatchPotentialValidationErrorResponse);
        }

        public static IActionResult MatchResponse<T1, T2, T3>(this OneOf<T1, T2, T3> oneOf)
        {
            return oneOf.Match(
                MatchPotentialValidationErrorResponse,
                MatchPotentialValidationErrorResponse,
                MatchPotentialValidationErrorResponse);
        }

        public static IActionResult MatchPotentialValidationErrorResponse<T>(T t)
        {
            if (t is IValidationError validationError)
            {
                return new BadRequestObjectResult(new ErrorResponse(validationError.Message));
            }

            return new OkObjectResult(t);
        }
    }
}
