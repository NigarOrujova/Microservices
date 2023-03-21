using CodeAcademy.Services.Basket.Dtos;
using CodeAcademy.Shared.Results;

namespace CodeAcademy.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);

        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);

        Task<Response<bool>> Delete(string userId);
    }
}