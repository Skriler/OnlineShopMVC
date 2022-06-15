using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineShopMVC.Middlewares
{
    public class CustomRoutingMiddleware
    {
        private static int STATUS_CODE_NOT_FOUND = 404;

        private static string SECRET_PLACE_URL = "/secretplace";

        private readonly RequestDelegate next;

        public CustomRoutingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();

            if (path == SECRET_PLACE_URL)
            {
                await context.Response.WriteAsync("Secret Page");
            }
            else
            {
                context.Response.StatusCode = STATUS_CODE_NOT_FOUND;
            }
        }
    }
}
