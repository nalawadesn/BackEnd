using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPMS.Models;

namespace NPMS.Repository
{
    public interface IBooking
    {
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<IEnumerable<Booking>> GetBooking(string Useremail);
        Task<IEnumerable<Booking>> GetBookingById(int userId);
        Task<Booking> InsertBooking(Booking bobj);
        Task UpdateBooking(Booking bobj);
        Task DeleteBooking(int Bkid);
    }
}
