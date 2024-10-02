using Microsoft.AspNetCore.Mvc;
using Store.Repository.Interfaces;
using Store.Repository.Repository;
using Store.Services.CachService;
using Store.Services.HandleResponse;
using Store.Services.Services.Dtos;
using Store.Services.Services.ProductServices;

namespace Store.Web.Extinsions
{
    public static class ApplicationServiceExtinsion
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICachService, ICachService>();
            services.AddAutoMapper(typeof(ProductProfile));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actioncontext =>
                {
                    var Errors = actioncontext.ModelState
                    .Where(Model => Model.Value?.Errors.Count() > 0)
                    .SelectMany(Mode => Mode.Value?.Errors)
                    .Select(Error => Error.ErrorMessage)
                    .ToList();
                    var ErrorREsponse = new ValididtionErrorResponse
                    {
                        Errors = Errors,

                    };
                    return new BadRequestObjectResult(ErrorREsponse);
                };

            });
            return services;
        }
    }
}
