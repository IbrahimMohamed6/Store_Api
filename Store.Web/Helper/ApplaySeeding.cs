﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Data.Data.Contexts;
using Store.Data.Entities.Identity;
using Store.Repository;
using Store.Repository.ContextSeed;

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
                    var UserManeger = Services.GetRequiredService<UserManager<AppUser>>();
                    await Context.Database.MigrateAsync();
                    await StoreDbContextSeed.StoreSeedAsync(Context, LoggerFactory);
                    await StoreIdentityContextSeed.SeedUserAsync(UserManeger);
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
