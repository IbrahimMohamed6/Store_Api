using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.Services.CachService;
using System.Text;

namespace Store.Web.Helper
{
    public class CacheAttribute:Attribute,IAsyncActionFilter
    {
        private readonly int _timeToLive;

        public CacheAttribute(int TimeToLive)
        {
            _timeToLive = TimeToLive;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var CashSevice = context.HttpContext.RequestServices.GetRequiredService<ICachService>();

            var cach= GetCacheKey(context.HttpContext.Request);
            var CachResponce = await CashSevice.GetCaheResponseAsync(cach);
            if (!string.IsNullOrEmpty(CachResponce))
            {
                var contentREsult = new ContentResult()
                {
                    Content = CachResponce,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentREsult;
                return;
            }
            var Execute = await next();
            if(Execute.Result is OkObjectResult responce)
            {
                await CashSevice.SetCaheResponseAsync(cach, responce.Value, TimeSpan.FromSeconds(_timeToLive));
            }

        }
        private string GetCacheKey(HttpRequest request) 
        {
            StringBuilder cachkey= new StringBuilder();
            cachkey.Append($"{request.Path}");
            foreach(var (Key,value) in request.Query.OrderBy(X=>X.Key))
            {
                cachkey.Append($"{Key}-{value}");
                
            }
            return cachkey.ToString();
        }
    }
}
