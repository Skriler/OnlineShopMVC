using Microsoft.AspNetCore.Builder;

namespace OnlineShopMVC.Middlewares
{
    public static class CustomRoutingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomRouting(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomRoutingMiddleware>();
        }
    }
}
