using NPMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace NPMS.Repository
{
    public class BookingRepo :IBooking
    {
        private News_Paper_Management_SystemContext _bnt;

        public BookingRepo(News_Paper_Management_SystemContext bnt)  //Dependncy Inject
        {
            _bnt = new News_Paper_Management_SystemContext();
        }
        public async Task DeleteBooking(int Bkid)
        {
            var obj = await _bnt.Booking.FindAsync(Bkid);
            _bnt.Booking.Remove(obj);
            await _bnt.SaveChangesAsync();
        }
        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            return await _bnt.Booking.Select(i => i).ToListAsync();
        }
        public async Task<IEnumerable<Booking>> GetBooking(string Useremail)
        {
            return await _bnt.Booking.Where(i => i.User.UserEmail == Useremail).ToListAsync();
        }
        public async Task<IEnumerable<Booking>> GetBookingById(int userId) {
            return await _bnt.Booking.Where(i => i.UserId == userId).Select(i=>i).ToListAsync();
        }
        public async Task<Booking> InsertBooking(Booking bobj)
        {
            _bnt.Booking.Add(bobj);
            await _bnt.SaveChangesAsync();
            return bobj;
        }
        public async Task UpdateBooking(Booking bobj)
        {
            _bnt.Entry(bobj).State = EntityState.Modified;
            await _bnt.SaveChangesAsync();
        }

    }
}
