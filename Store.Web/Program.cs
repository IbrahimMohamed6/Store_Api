 using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Store.Data.Data.Contexts;
using Store.Web.Extinsions;
using Store.Web.Helper;
using Store.Web.MiddleWare;

namespace Store.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<StoreDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddDbContext<StoreIdentityDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });
            builder.Services.AddSingleton<IConnectionMultiplexer>(config =>
            {
                return ConnectionMultiplexer.Connect(ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("redis")));
            });
          builder.Services.AddApplicationServices(); 

            builder.Services.AddIdentityServices(builder.Configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerDocumention();
            builder.Services.AddCors(Options =>
            {
                Options.AddPolicy("CorsPolicy", Policy =>
                {
                    Policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http:localhost:4200");
                });
            });
            var app = builder.Build();
            await ApplaySeeding.ApplaySeedingAsync(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExceptionMiddleWare>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
