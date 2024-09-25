using Microsoft.EntityFrameworkCore;
using Store.Data.Data.Contexts;
using Store.Repository;

namespace Store.Web.Helper
{
    public class ApplaySeeding
    {
        public static async Task ApplaySeedingAsync(WebApplication app)
        {
            using (var Scope = app.Services.CreateScope())
            {
                var Services = Scope.ServiceProvider;
                var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var Context = Services.GetRequiredService<StoreDbContext>();
                    await Context.Database.MigrateAsync();
                    await StoreDbContextSeed.StoreSeedAsync(Context, LoggerFactory);
                }
                catch (Exception ex)
                {

                    var Logger = LoggerFactory.CreateLogger<ApplaySeeding>();
                    Logger.LogError(ex.Message);
                }
            }
        }
    }
}
