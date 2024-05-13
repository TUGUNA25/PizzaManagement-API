using PizzaManagement.API.Infrastructure.Middlewares;

namespace PizzaManagement.API.Infrastructure.Extensions
{
    public static class CultureMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<CultureMiddleware>();

            return builder;
        }
    }
}
