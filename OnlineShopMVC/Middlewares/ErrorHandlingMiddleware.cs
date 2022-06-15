using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnlineShopMVC.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private static int STATUS_CODE_NOT_FOUND = 404;

        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await next.Invoke(context);

            if (context.Response.StatusCode == STATUS_CODE_NOT_FOUND)
            {
                await context.Response.WriteAsync("Not Found");
            }
        }
    }
}
