namespace Geo.Api.Middleware;

public static class MiddleWareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleWare>();
    }
}