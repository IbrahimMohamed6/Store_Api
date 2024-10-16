using Microsoft.AspNetCore.Mvc;
using Store.Repository.BasketRepository;
using Store.Repository.Interfaces;
using Store.Repository.Repository;
using Store.Services.CachService;
using Store.Services.HandleResponse;
using Store.Services.Services.BasketService;
using Store.Services.Services.BasketService.Dtos;
using Store.Services.Services.Dtos;
using Store.Services.Services.OrderServices;
using Store.Services.Services.OrderServices.Dto;
using Store.Services.Services.PaymentServices;
using Store.Services.Services.ProductServices;
using Store.Services.Services.TokenService;
using Store.Services.Services.UserServices;

namespace Store.Web.Extinsions
{
    public static class ApplicationServiceExtinsion
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICachService, CaheService>();
            services.AddScoped<IBasketService, BasketServices>();
            services.AddScoped<ITokenServices, TokenServices>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPayemntService, PayemntService>();
            services.AddScoped<IBasketRepository, BasketRepo>();
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddAutoMapper(typeof(BasketProfile));
            services.AddAutoMapper(typeof(OrderProfile));
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
