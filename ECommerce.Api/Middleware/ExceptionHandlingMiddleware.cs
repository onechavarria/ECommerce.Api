using ECommerce.Api.Responses;
using System.Net;
using System.Text.Json;

namespace ECommerce.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _environment;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IWebHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
            
        }

       public async Task InvokeAsync(HttpContext context)
       {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
       }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An unhandled exception occured.");
            context.Response.ContentType = "application/json";

            var statusCode = exception switch
            {
                KeyNotFoundException => HttpStatusCode.NotFound,
                ArgumentException => HttpStatusCode.BadRequest,
                UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                _ => HttpStatusCode.InternalServerError
            };

            context.Response.StatusCode = (int)statusCode;
            var response = new ApiErrorResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = statusCode switch
                {
                    HttpStatusCode.NotFound => "the requested ressource was not found",
                    HttpStatusCode.BadRequest => "the request is invalid.",
                    HttpStatusCode.Unauthorized => "You are not authorized to perform this action.",
                    _ => "An unexpected error accured."
                },

                Datails = _environment.IsDevelopment() ? exception.Message : null
            };

            
            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
            
        }

        
           
    }
}
