using GroceryAPI.Extensions;
using GroceryAPI.Middlewares;
namespace GroceryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.RegisterAndConfigureServices();

            var app = builder.Build();

            app.UseCustomExceptionHandlerMiddleware();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
