using NPMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPMS.Repository
{
    public interface IPayment
    {
        Task<IEnumerable<Payment>> GetAllPayments();
        Task<Payment> GetPayment(int Paymentid);
        Task<Payment> InsertPayment(Payment pobj);
        Task UpdatePayment(Payment pobj);
        Task DeletePayment(int Paymentid);
    }
}
