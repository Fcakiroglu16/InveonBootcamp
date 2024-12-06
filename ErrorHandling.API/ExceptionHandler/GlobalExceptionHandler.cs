using Microsoft.AspNetCore.Diagnostics;

namespace ErrorHandling.API.ExceptionHandler
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            // log.logError("kullanıcı login olamadı,");


            logger.LogError(exception, "An error occurred while processing your request. Please try again later.");




            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.WriteAsJsonAsync(new
            {
                Message = "An error occurred while processing your request. Please try again later.",
                MachineId = 1,
                UserId = 1
            });


            return ValueTask.FromResult(true);

        }
    }
}
