using Core.Extensions;
using Core.Filters.Authorization;

namespace ReturnedProductService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddControllers(opt => opt.Filters.Add(typeof(AuthorizeAttribute))); // her method için istek authentication  kontrol edilsin
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();
            app.UseExceptionMiddleware();
            app.Run();
        }
    }
}