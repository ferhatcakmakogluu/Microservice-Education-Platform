using OnlineCourse.Web.Models.FakePayments;
using OnlineCourse.Web.Services.Interfaces;
using System.Threading.Tasks;

namespace OnlineCourse.Web.Services
{
    public class PaymentService : IPaymentService
    {
        public Task<bool> ReceivePayment(PaymentInfoInput paymentInfoInput)
        {
            throw new System.NotImplementedException();
        }
    }
}
