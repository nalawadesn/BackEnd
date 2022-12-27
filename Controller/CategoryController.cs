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
    public class CategoryController : ControllerBase
    {
        private ICategory _ct;
        public CategoryController(ICategory ct)  //Dependency Inject
        {
            _ct = ct;
        }
        // GET: api/<CategorysController>
        [HttpGet]
        public async Task<IEnumerable<Category>> getCategory()
        {
            return await _ct.GetAllCategories();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> getCategory(int Categoryid)
        {
            return await _ct.GetCategory(Categoryid);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<Category>> PostUser([FromBody] Category cobj)
        {
            var newCategory = await _ct.InsertCategory(cobj);
            return CreatedAtAction(nameof(getCategory), new { id = newCategory.CategoryId }, newCategory);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> updateCategory(int id, [FromBody] Category cobj)
        {
            if (id != cobj.CategoryId)
            {
                return BadRequest();

            }
            await _ct.UpdateCategory(cobj);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteUser(int id)
        {
            var res = await _ct.GetCategory(id);
            if (res == null)
            {
                return NoContent();
            }
            await _ct.DeleteCategory(id);
            return NoContent();
        }
    }
}
