using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
public class RegistryManagementController : Controller
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{uuid}")]
        //public void Delete(int id)
        public IActionResult DeleteReg(Guid uuid)
        {
        
             try
            {
              //  _context.Remove(deleteProductFamily);
              //  await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }
    }
}