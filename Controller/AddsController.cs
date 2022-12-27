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
    public class AddsController : ControllerBase
    {
        private IAdds _adt;
        public AddsController(IAdds adt)  //Dependency Inject
        {
            _adt = adt;
        }
        // GET: api/<AddsController>
        [HttpGet]
        public async Task<IEnumerable<Adds>> getAdds()
        {
            return await _adt.GetAllAdds();
        }

        // GET api/<AddController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adds>> getAdd(int Addid)
        {
            return await _adt.GetAdd(Addid);
        }

        // POST api/<AddController>
        [HttpPost]
        public async Task<ActionResult<Adds>> PostAdd([FromBody] Adds adobj)
        {
            var newAdd = await _adt.InsertAdd(adobj);
            return CreatedAtAction(nameof(getAdd), new { id = newAdd.AddId }, newAdd);
        }

        // PUT api/<AddController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> updateAdd(int id, [FromBody] Adds adobj)
        {
            if (id != adobj.AddId)
            {
                return BadRequest();

            }
            await _adt.UpdateAdd(adobj);
            return NoContent();
        }

        // DELETE api/<AddController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteAdd(int id)
        {
            var res = await _adt.GetAdd(id);
            if (res == null)
            {
                return NoContent();
            }
            await _adt.DeleteAdd(id);
            return NoContent();
        }
    }
}
