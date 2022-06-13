namespace Calculator.Middleware.CustomExceptionHandler.Extensions;

public static class DependencyInjection
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}