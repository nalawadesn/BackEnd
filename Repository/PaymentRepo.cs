using NPMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace NPMS.Repository
{
    public class PaymentRepo : IPayment
    {
        private News_Paper_Management_SystemContext _pnt;

        public PaymentRepo(News_Paper_Management_SystemContext pnt)  //Dependncy Inject
        {
            _pnt = new News_Paper_Management_SystemContext();
        }
        public async Task DeletePayment(int Paymentid)
        {
            var obj = await _pnt.Payment.FindAsync(Paymentid);
            _pnt.Payment.Remove(obj);
            await _pnt.SaveChangesAsync();
        }
        public async Task<IEnumerable<Payment>> GetAllPayments()
        {
            return await _pnt.Payment.Select(i => i).ToListAsync();
        }
        public async Task<Payment> GetPayment(int Paymentid)
        {
            return await _pnt.Payment.FindAsync(Paymentid);
        }
        public async Task<Payment> InsertPayment(Payment pobj)
        {
            _pnt.Payment.Add(pobj);
            await _pnt.SaveChangesAsync();
            return pobj;
        }
        public async Task UpdatePayment(Payment pobj)
        {
            _pnt.Entry(pobj).State = EntityState.Modified;
            await _pnt.SaveChangesAsync();
        }
    }
}
