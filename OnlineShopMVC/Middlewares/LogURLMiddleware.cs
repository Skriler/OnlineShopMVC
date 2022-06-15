using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions;

namespace OnlineShopMVC.Middlewares
{
    public class LogURLMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<LogURLMiddleware> logger;

        public LogURLMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next;
            logger = loggerFactory?.CreateLogger<LogURLMiddleware>() ?? 
                throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            logger.LogInformation($"Request URL: { UriHelper.GetDisplayUrl(context.Request)}");
            await next.Invoke(context);
        }
    }
}
