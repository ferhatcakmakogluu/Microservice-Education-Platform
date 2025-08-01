using OnlineCourse.Web.Models.Discounts;
using System.Threading.Tasks;

namespace OnlineCourse.Web.Services.Interfaces
{
    public interface IDiscountService
    {
        Task<DiscountViewModel> GetDiscount(string discountCode);
    }
}
