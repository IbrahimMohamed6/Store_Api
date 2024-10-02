


using Microsoft.EntityFrameworkCore.Diagnostics;
using StackExchange.Redis;
using System.Text.Json;

namespace Store.Services.CachService
{
    public class CaheService : ICachService
    {
        private readonly IDatabase _database;

        public CaheService(IConnectionMultiplexer redis)
        {
            _database= redis.GetDatabase();
        }
        public async Task<string> GetCaheResponseAsync(string Key)
        {

            var CachResponse=await _database.StringGetAsync(Key);
            if(CachResponse.IsNullOrEmpty)
                return null;
            return CachResponse.ToString();
        }

        public async Task SetCaheResponseAsync(string Key, object Response, TimeSpan TimeToLive)
        {
            if (Response == null)
                return;
            var Option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var SerilizedResponse = JsonSerializer.Serialize(Response, Option);

            await _database.StringSetAsync(Key, SerilizedResponse, TimeToLive);
        }
    }
}
