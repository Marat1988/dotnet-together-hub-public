using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Api.Exceptions.Handler
{
    public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            logger.LogWarning("Обработанное исключение {Message}, время: {time}", exception.Message, DateTime.Now);

            (string Detail, string Title, int StatusCode) details = exception switch
            {
                NotFoundException => (
                    exception.Message,
                    exception.GetType().Name,
                    httpContext.Response.StatusCode = StatusCodes.Status404NotFound
                ),



                _ => (
                    exception.Message,
                    exception.GetType().Name,
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError
                )
            };

            var problerDetails = new ProblemDetails
            {
                Title = details.Title,
                Detail = details.Detail,
                Status = details.StatusCode,
                Instance = httpContext.Request.Path
            };

            problerDetails.Extensions.Add("traceId", httpContext.TraceIdentifier);

            await httpContext
                .Response
                .WriteAsJsonAsync(problerDetails, cancellationToken);
            return true;
        }
    }
}
