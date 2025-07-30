using OnlineCourse.Web.Models;
using System.Threading.Tasks;

namespace OnlineCourse.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();
    }
}
