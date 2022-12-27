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
    public class PaymentController : ControllerBase
    {
        private IPayment _pt;
        public PaymentController(IPayment pt)  //Dependency Inject
        {
            _pt = pt;
        }
        // GET: api/<PaymentController>
        [HttpGet]
        public async Task<IEnumerable<Payment>> getPayments()
        {
            return await _pt.GetAllPayments();
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> getPayment(int id)
        {
            return await _pt.GetPayment(id);
        }

        // POST api/<PaymentController>
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment([FromBody] Payment uobj)
        {
            var newDepartment = await _pt.InsertPayment(uobj);
            return CreatedAtAction(nameof(getPayment), new { id = newDepartment.PaymentId }, newDepartment);
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> updatePayment(int id, [FromBody] Payment uobj)
        {
            if (id != uobj.PaymentId)
            {
                return BadRequest();

            }
            await _pt.UpdatePayment(uobj);
            return NoContent();
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> deletePayment(int id)
        {
            var res = await _pt.GetPayment(id);
            if (res == null)
            {
                return NoContent();
            }
            await _pt.DeletePayment(id);
            return NoContent();
        }
    }
}
