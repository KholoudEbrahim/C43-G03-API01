
using Domain.Contracts;
using E_Commerce.Web.Middlewares;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;
using Persistence.Repositories;
using Services;
using ServicesAbstractions;

namespace E_Commerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });


            builder.Services.AddScoped<IDbInitializer, DbInitializer>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddAutoMapper(typeof (Services.AssemblyReference).Assembly);
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
           



            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            await InitializerDbAsync(app);
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
            //app.Use(async (context ,next) => 
            //    {
            //    Console.WriteLine("Processing Request");
            //    await next.Invoke();
            //    Console.WriteLine("Writing Response");
            //    Console.WriteLine(context.Response);
            //    });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();

            app.Run();

        }
        public static async Task InitializerDbAsync(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbIntializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await dbIntializer.InitializerAsync();
        }

    }
}
//GetAllProduct     => Product
// GetById          => Product
// GetBrands        => Brands
//GetTypes          => Types