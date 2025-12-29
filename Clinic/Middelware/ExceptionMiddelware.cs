using Clinic.Infrastructure.Presistence.Helper;
using System.Net;
using System.Text.Json;

namespace Clinic.APIs.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _env;
    private readonly ILogger<ExceptionMiddleware> _logger;
    //------------------------------------------------------------------------------------------
    public ExceptionMiddleware(RequestDelegate next,IHostEnvironment env,ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _env = env;
        _logger = logger;
    }
    //------------------------------------------------------------------------------------------
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception ex)
        {
            await HandleExceptionAsync(context,ex);
        }
    }
    //------------------------------------------------------------------------------------------
    private Task HandleExceptionAsync(HttpContext context,Exception exception)
    {
        _logger.LogError(exception,"Unhandled exception occurred");

        int statusCode = exception switch
        {
            UnauthorizedAccessException => (int) HttpStatusCode.Unauthorized,
            KeyNotFoundException => (int) HttpStatusCode.NotFound,
            InvalidOperationException => (int) HttpStatusCode.BadRequest,
            _ => (int) HttpStatusCode.InternalServerError
        };

        var response = _env.IsDevelopment()
            ? new ApiExceptions(statusCode,exception.Message,exception.StackTrace)
            : new ApiExceptions(statusCode,"حدث خطأ غير متوقع، برجاء المحاولة لاحقاً.");

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var jsonResponse = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(jsonResponse);
    }
    //------------------------------------------------------------------------------------------
}
