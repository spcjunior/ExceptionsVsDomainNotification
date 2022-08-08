using ExceptionsVsDomainNotification.ExceptionApi.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionsVsDomainNotification.ExceptionApi.Middlewares
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled && context.Exception is DomainException domainException)
            {
                context.Result = new BadRequestObjectResult(new
                {
                    error = domainException.Message,
                    errorMessage = string.Join(",", domainException.Errors.Select(e => e.Message))
                });
                context.ExceptionHandled = true;
            }
        }
    }
}
