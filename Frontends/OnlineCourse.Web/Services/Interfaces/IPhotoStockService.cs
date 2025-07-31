using Microsoft.AspNetCore.Http;
using OnlineCourse.Web.Models.PhotoStocks;
using System.Threading.Tasks;

namespace OnlineCourse.Web.Services.Interfaces
{
    public interface IPhotoStockService
    {
        Task<PhotoViewModel> UploadPhoto(IFormFile photo);
        Task<bool> DeletePhoto(string photoUrl);
    }
}
