using Microsoft.AspNetCore.Http;
using OnlineCourse.Web.Models.PhotoStocks;
using OnlineCourse.Web.Services.Interfaces;
using System.Threading.Tasks;

namespace OnlineCourse.Web.Services
{
    public class PhotoStockService : IPhotoStockService
    {
        public Task<bool> DeletePhoto(string photoUrl)
        {
            throw new System.NotImplementedException();
        }

        public Task<PhotoViewModel> UploadPhoto(IFormFile photo)
        {
            throw new System.NotImplementedException();
        }
    }
}
