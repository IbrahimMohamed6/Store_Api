

using Store.Repository.BasketRepository.Models;

namespace Store.Repository.BasketRepository
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsy(string BasketId);
        Task<CustomerBasket> UpdateBasketAsy(CustomerBasket BAsket);
        Task<bool> DeleteBAsketAsy(string BasketId);

    }
}
