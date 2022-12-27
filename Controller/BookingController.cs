using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPMS.Repository;
using NPMS.Models;

namespace NPMS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBooking _bt;
        public BookingController(IBooking bt)  //Dependency Inject
        {
            _bt = bt;
        }
        // GET: api/<BookingController>
        [HttpGet]
        public async Task<IEnumerable<Booking>> getBooking()
        {
            return await _bt.GetAllBookings();
        }

        // GET api/<BookingController>/5
        [HttpGet("{Useremail}")]
        public async Task<IEnumerable<Booking>> getBooking(string Useremail)
        {
            return await _bt.GetBooking(Useremail);
        }

        [HttpGet("{id:int}")]
        public async Task<IEnumerable<Booking>> getBookingByUserId(int id)
        {
            return await _bt.GetBookingById(id);
        }

        // POST api/<BookingController>
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking([FromBody] Booking Bkobj)
        {
            var newBooking = await _bt.InsertBooking(Bkobj);
            return CreatedAtAction(nameof(getBooking), new { id = newBooking.BkId}, newBooking);
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> updateBooking(int id, [FromBody] Booking bobj)
        {
            if (id != bobj.BkId)
            {
                return BadRequest();

            }
            await _bt.UpdateBooking(bobj);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{Bkid}")]
        public async Task<ActionResult> deleteUser(int Bkid)
        {
            await _bt.DeleteBooking(Bkid);
            return NoContent();
        }
    }
}
