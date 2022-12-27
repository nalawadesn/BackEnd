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
    public class AdminController : ControllerBase
    {
        private IAdmin _at;
        public AdminController(IAdmin at)  //Dependency Inject
        {
            _at = at;
        }
        // GET: api/<AdminController>
        [HttpGet]
        public async Task<IEnumerable<Admin>> getAdmins()
        {
            return await _at.GetAllAdmins();
        }

        // GET api/<AdminController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Admin>> getAdmin(int id)
        {
            return await _at.GetAdmin(id);
        }


        // POST api/<AdminController>
        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin([FromBody] Admin aobj)
        {
            var newAdminIn = await _at.InsertAdmin(aobj);
            return CreatedAtAction(nameof(getAdmin), new { id = newAdminIn.AdminId }, newAdminIn);
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> updateAdmin(int id, [FromBody] Admin aobj)
        {
            if (id != aobj.AdminId)
            {
                return BadRequest();

            }
            await _at.UpdateAdmin(aobj);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteAdmin(int id)
        {
            var res = await _at.GetAdmin(id);
            if (res == null)
            {
                return NoContent();
            }
            await _at.GetAdmin(id);
            return NoContent();
        }

        [HttpPut("{email}")]
        public async Task<ActionResult<Admin>> getAdminByEmail(Adminlogin Adminlogin)
        {
            var det = await _at.GetAdminbyemail(Adminlogin);
            if (det == null)
            {
                return NoContent();
            }
            return det;
        }
    }
}
