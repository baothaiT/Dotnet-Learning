using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CS004_SwaggerUI.Middleware
{
    public class TraceIdMiddleware
    {
        private readonly RequestDelegate _next;
        private const string TraceIdHeader = "TraceId";

        public TraceIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Ensure Activity exists
            if (Activity.Current == null)
            {
                var activity = new Activity("Request");
                activity.Start();
            }

            var traceId = Activity.Current?.TraceId.ToString() ?? string.Empty;
            if (!string.IsNullOrEmpty(traceId))
            {
                context.Response.OnStarting(() => {
                    context.Response.Headers[TraceIdHeader] = traceId;
                    return Task.CompletedTask;
                });
            }

            await _next(context);
        }
    }
}
