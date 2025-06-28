using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AccountingLedgerSystem.API.Exceptions
{
    // Custom exception handler
    public sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
            => _logger = logger;

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Unhandled exception occurred");

            var problemDetails = new ProblemDetails
            {
                Title = "An error occurred",
                Detail = exception.Message,
                Status = StatusCodes.Status500InternalServerError,
                Instance = httpContext.Request.Path
            };

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;
        }
    }
}
