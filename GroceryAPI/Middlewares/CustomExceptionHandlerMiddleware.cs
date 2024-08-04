namespace GroceryAPI.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _environment;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment environment)
        {
            _next = next;
            _environment = environment;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    await httpContext.Response.WriteAsJsonAsync(
                        new
                        {
                            StatusCode = 500,
                            ex.Message,
                            ex.InnerException,
                            ex.StackTrace
                        }
                    );
                }
                else
                {
                    await httpContext.Response.WriteAsJsonAsync(
                        new
                        {
                            StatusCode = 500,
                            Message = "Internal server error :<"
                        }
                    );
                }

            }
        }
    }

    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
