using Store.Repository.BasketRepository.Models;
using Store.Services.Services.BasketService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.BasketService
{
    public interface IBasketService
    {

        Task<CustomerBasketDto> GetBasketAsy(string BasketId);
        Task<CustomerBasketDto> UpdateBasketAsy(CustomerBasketDto BAsket);
        Task<bool> DeleteBAsketAsy(string BasketId);
    }
}
