using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace DevFreela.API.ExceptionHandlers
{
    public class ValidationExceptionHandler(IProblemDetailsService problemDetails) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ValidationException ex) return false;  // outras exceções seguem o fluxo normal

            var errors = ex.Errors
               .GroupBy(e => e.PropertyName)
               .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            return await problemDetails.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = ex,
                ProblemDetails = new HttpValidationProblemDetails(errors)
                {
                    Title = "One or more validation errors occurred.",
                    Status = StatusCodes.Status400BadRequest
                }
            });
        }
    }
}
