using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPMS.Repository;
using NPMS.Models;
using Microsoft.EntityFrameworkCore;

namespace NPMS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser _ut;
        public UserController(IUser ut)  //Dependency Inject
        {
            _ut = ut;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<Userdet>> getUser()
        {
            return await _ut.GetAllUsers();
        }

        // GET api/<UserController>/
        //[HttpGet("{id : int}")]
        //public async Task<ActionResult<Userdet>> getUser(int id)
        //{
        //    return await _ut.GetUser(id);
        //}

        [HttpGet("{Useremail}")]
        public async Task<ActionResult<Userdet>> getUserdetbyemail(string Useremail)
        {
            var det= await _ut.GetUserdetbyemail(Useremail);
            if (det == null) {
                return NoContent();
            }
            return det;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<Userdet>> PostUser([FromBody] Userdet uobj)
        {
            var newDepartment = await _ut.InsertUser(uobj);
            return CreatedAtAction(nameof(getUser), new { id = newDepartment.UserId }, newDepartment);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> updateUser(int id, [FromBody] Userdet uobj)
        {
            if (id != uobj.UserId)
            {
                return BadRequest();

            }
            await _ut.UpdateUser(uobj);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{Useremail}")]
        public async Task<ActionResult> deleteUser(string Useremail)
        {
            var res = await _ut.GetUserdetbyemail(Useremail);
            if (res == null)
            {
                return NoContent();
            }
            await _ut.DeleteUser(res.UserId);
            return NoContent();
        }

        [HttpPut("{email}")]
        public async Task<ActionResult<Userdet>> getUsersByEmail(Userlogin userDet)
        {
            var det = await _ut.GetUserbyemail(userDet);
            if (det == null)
            {
                return NoContent();
            }
            return det;
        }

        //[HttpGet("{email}")]

        //public async Task<ActionResult<Userdet>> GetUserbyemail(string email)
        //{
        //    News_Paper_Management_SystemContext _nt = new News_Paper_Management_SystemContext();
        //    var res = await _nt.Userdet.Where(i => i.UserEmail == email).FirstOrDefaultAsync();
        //    if(res == null)
        //    {
        //        return NoContent();
        //    }
        //    return res;
        //}
    }
}
