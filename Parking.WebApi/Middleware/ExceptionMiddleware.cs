using System.Net;
using System.Text.Json;

namespace Parking.WebApi.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception");

            var (status, message) = MapException(ex);
            context.Response.StatusCode = (int)status;
            context.Response.ContentType = "application/json";

            var response = new
            {
                error = message,
                status = status.ToString()
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }

    private static (HttpStatusCode status, string message) MapException(Exception ex)
        => ex switch
        {
            InvalidOperationException => (HttpStatusCode.BadRequest, ex.Message),
            _ => (HttpStatusCode.InternalServerError, "An unknown error occurred.")
        };
}