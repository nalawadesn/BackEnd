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
    public class AddListController : ControllerBase
    {
        private IAddLists _lt;
        public AddListController(IAddLists lt)  //Dependency Inject
        {
            _lt = lt;
        }
        // GET: api/<AddlistsController>
        [HttpGet]
        public async Task<IEnumerable<AddLists>> getAllAddlists()
        {
            return await _lt.GetAllAddLists();
        }

        // GET api/<AddlistController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddLists>> getAddlist(int id)
        {
            return await _lt.GetAddlist(id);
        }
      
        // POST api/<AddlistController>
        [HttpPost]
        public async Task<ActionResult<AddLists>> PostAddList([FromBody] AddLists lobj)
        {
            var newAddlists = await _lt.InsertAddlist(lobj);
            return CreatedAtAction(nameof(getAddlist), new { id = newAddlists.AddListId }, newAddlists);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> updateAddList(int id, [FromBody] AddLists lobj)
        {
            if (id != lobj.AddListId)
            {
                return BadRequest();

            }
            await _lt.UpdateAddlist(lobj);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteAddlist(int lid)
        {
            var res = await _lt.GetAddlist(lid);
            if (res == null)
            {
                return NoContent();
            }
            await _lt.GetAddlist(lid);
            return NoContent();
        }

    }
}
