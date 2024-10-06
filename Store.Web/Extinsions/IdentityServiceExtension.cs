﻿using Microsoft.AspNetCore.Identity;
using Store.Data.Data.Contexts;
using Store.Data.Entities.Identity;

namespace Store.Web.Extinsions
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<AppUser>();
            builder=new IdentityBuilder(builder.UserType,builder.Services);
            builder.AddEntityFrameworkStores<StoreIdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication();

            return services;
        }
    }
}
