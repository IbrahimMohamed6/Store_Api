using StackExchange.Redis;
using Store.Repository.BasketRepository.Models;
using System.Text.Json;

namespace Store.Repository.BasketRepository
{
    public class BasketRepo : IBasketRepository
    {
        private readonly IDatabase _database;

        public BasketRepo(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<bool> DeleteBAsketAsy(string BasketId)
    => await _database.KeyDeleteAsync(BasketId);

        public async Task<CustomerBasket> GetBasketAsy(string BasketId)
        {
            var Basket = await _database.StringGetAsync(BasketId);

            return Basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(Basket);
        }

        public async Task<CustomerBasket> UpdateBasketAsy(CustomerBasket BAsket)
        {
            var isCreated = await _database.StringSetAsync(BAsket.Id, JsonSerializer.Serialize(BAsket), TimeSpan.FromDays(30));

            if (!isCreated)
                return null;
            return await GetBasketAsy(BAsket.Id);
        }
    }
}
