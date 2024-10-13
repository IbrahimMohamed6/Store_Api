using Microsoft.OpenApi.Models;

namespace Store.Web.Extinsions
{
    public static class SwaggerServerExtensions
    {
        public static IServiceCollection AddSwaggerDocumention(this IServiceCollection services)
        {
            services.AddSwaggerGen(Options =>
            {
                Options.SwaggerDoc("V1", new OpenApiInfo
                {
                    Title = "StoreApi",
                    Version = "v1",
                    Contact=new OpenApiContact
                    {
                        Name ="Hema",
                        Email="Hema@gmail.Com",
                        Url=new Uri("https://www.youtube.com/")
                    }
                });
                var SecurityScheme = new OpenApiSecurityScheme()
                {
                    Description = "Authorization Is Important",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    Reference = new OpenApiReference()
                    {
                        Id= "bearer",
                        Type=ReferenceType.SecurityScheme
                    }


                };
                Options.AddSecurityDefinition("bearer",SecurityScheme);
                var SecurityRequerments = new OpenApiSecurityRequirement
                {
                    {SecurityScheme,new[]{ "bearer" } }
                };
                Options.AddSecurityRequirement(SecurityRequerments);

            });
            return services;
        }
    }
}
