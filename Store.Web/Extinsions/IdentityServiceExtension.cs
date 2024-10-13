using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Store.Data.Data.Contexts;
using Store.Data.Entities.Identity;
using System.Text;

namespace Store.Web.Extinsions
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services
            ,IConfiguration _config)
        {
            var builder = services.AddIdentityCore<AppUser>();
            builder=new IdentityBuilder(builder.UserType,builder.Services);
            builder.AddEntityFrameworkStores<StoreIdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey=true,
                        IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"])),
                        ValidateIssuer=true,
                        ValidIssuer = _config["Token:Key"],
                        ValidateAudience=false,

                    };
                });

            return services;
        }
    }
}
