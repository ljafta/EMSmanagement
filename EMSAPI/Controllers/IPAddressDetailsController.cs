using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMS.Models;
using EMS.Models.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EMS.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
public class IPAddressDetailsController : ControllerBase
    {

        private readonly EMSDBContext _context;
         //EMSDBContext _context = new EMSDBContext();
         public IPAddressDetailsController(EMSDBContext context)
        {
            _context = context;
            
        }

        /// <summary>
        /// List all sofwaredetails
        /// </summary>

        [HttpGet]
        [Route("GetIPAdd")]
        public async Task<IActionResult> GetIPAdd(Guid uuid)
        {
            try {
                var results = await _context.IPAddressDetails.Where(c => c.AgentDeviceuuid == uuid).ToListAsync();
                return Ok(results);
            }
            catch (Exception error) {
             
                return BadRequest(error);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

          /// <summary>
        /// Create an Email approval
        /// </summary>
        [HttpPost]
         [Route("CreateIPAddress")]
        public IActionResult PutEmail([FromBody] List<IPAddressDetails> ipaddrss) 
               {      
              try {
                   foreach( var ipadd in ipaddrss)
                {

                 // Mapping
                IPAddressDetails ipdetails= new IPAddressDetails()  
                {
                    UUID = Guid.NewGuid(),    
                    AgentDeviceuuid = ipadd.AgentDeviceuuid,
                    Description = ipadd.Description,
                    IPAddress = ipadd.IPAddress               
                  
                };
                
               _context.IPAddressDetails.Add(ipdetails);              
                }           
               _context.SaveChanges();               
            }
            catch (Exception error) {
             
                return BadRequest(error);
            }
                  return Ok();
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}