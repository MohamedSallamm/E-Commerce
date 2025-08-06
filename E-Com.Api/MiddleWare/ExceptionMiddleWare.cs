using E_Com.Api.Helper;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Text.Json;

namespace E_Com.Api.MiddleWare
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _environment;
        private readonly IMemoryCache _memoryCache;
        private readonly TimeSpan _RateLimitWindow = TimeSpan.FromSeconds(30);

        public ExceptionMiddleWare(RequestDelegate next, IHostEnvironment environment, IMemoryCache memoryCache)
        {
            _next = next;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _memoryCache = memoryCache;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                ApplySecurity(context);


                if (ISRequestAllowed(context) == false)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    context.Response.ContentType = "application/Json";
                    var response = new
                        APIExceptions((int)HttpStatusCode.TooManyRequests, "Too many requests. Please try again later.");
                    await context.Response.WriteAsJsonAsync(response);

                }
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/Json";

                var response = _environment.IsDevelopment() ?
                    new APIExceptions((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                    : new APIExceptions((int)HttpStatusCode.InternalServerError, ex.Message);


                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
        private bool ISRequestAllowed(HttpContext httpContext)
        {
            var ip = httpContext.Connection?.RemoteIpAddress?.ToString();
            var cachKey = $"Rate:{ip}";
            var DateNow = DateTime.Now;
            var (TimesTamp, count) = _memoryCache.GetOrCreate(cachKey,
                entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
                return (DateTime.Now, 0);
            });
            if (DateNow - TimesTamp < _RateLimitWindow)
            {
                if (count >= 8)
                {
                    return false;
                }
                _memoryCache.Set(cachKey, (TimesTamp, count += 1), _RateLimitWindow);
            }
            else
            {
                _memoryCache.Set(cachKey, (DateTime.Now, 1), _RateLimitWindow);
            }
            return true;
        }

        public void ApplySecurity(HttpContext context)
        {
            context.Response.Headers["X-Content-Type-Options"] = "nosniff";
            context.Response.Headers["X-XSS-Protection"] = "1; mode = block";
            context.Response.Headers["X-Frame-Options"] = "DENY";

            // CSP – Content Security Policy
            context.Response.Headers["Content-Security-Policy"] =
                "default-src 'self'; " +
                "script-src 'self'; " +
                "style-src 'self'; " +
                "img-src 'self'; " +
                "font-src 'self'; " +
                "object-src 'none'; " +
                "frame-ancestors 'none';";

            // Referrer Policy
            context.Response.Headers["Referrer-Policy"] = "no-referrer";
        }

    }
}
