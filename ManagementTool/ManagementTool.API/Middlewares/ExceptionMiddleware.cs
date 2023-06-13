using ManagementTool.API.Contracts;
using System.Net;

namespace ManagementTool.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                
                await _next(httpContext);
              
            }
            catch (Exception exception)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var error = new Error
                {
                    StatusCode = httpContext.Response.StatusCode.ToString(),
                    Message = exception.Message

                };

                await httpContext.Response.WriteAsync(error.ToString());
            }
        }     
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
