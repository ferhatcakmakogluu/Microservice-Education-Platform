using OnlineCourse.Web.Models.FakePayments;
using System.Threading.Tasks;

namespace OnlineCourse.Web.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput);
    }
}
