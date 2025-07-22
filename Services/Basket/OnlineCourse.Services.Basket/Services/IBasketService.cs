using OnlineCourse.Services.Basket.Dtos;
using OnlineCourse.Shared.Dtos;
using System.Threading.Tasks;

namespace OnlineCourse.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basket);
        Task<Response<bool>> Delete(string userId);
    }
}
