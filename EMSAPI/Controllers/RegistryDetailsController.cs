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
        public class RegistryDetailsController : Controller
        {
         private readonly EMSDBContext _context;
         //EMSDBContext _context = new EMSDBContext();
         public RegistryDetailsController(EMSDBContext context)
        {
            _context = context;
            
        }

         /// <summary>
        /// List all ComputerInfo (Devices)
        /// </summary>
// GET api/values/5
        [HttpGet]
        [Route("{uuid}")]
        public async Task<IActionResult> GetHardwareID(Guid uuid)
        {
              
           try {
                var results = await _context.RegistryDetails.Where(c => c.AgentDeviceuuid == uuid).ToListAsync();
                return Ok(results);
            }
            catch (Exception error) {
             
                return BadRequest(error);
            }
        }

         /// <summary>
        /// List of all Registry values 
        /// </summary>

          [HttpGet]
        [Route("GetRegInfo")]
        public async Task<IActionResult> GetRegistry()
        {
        try{
            return Ok(await _context.RegistryDetails.ToListAsync());
        }
              catch (Exception ex)
            {
                ex.Message.ToString();
                return StatusCode(500, ex);
            }
        }

         // DELETE api/values/5
        [HttpDelete("{uuid}")]
        public void DelRegisttry(Guid uuid)
        {
            
        }

        /// <summary>
        /// Create an Email approval
        /// </summary>
        [HttpPost]
         [Route("CreateRegistryValues")]
        public IActionResult PutEmail([FromBody] List<RegistryDetails> rvalues) 
               {        
                   try{
                foreach( var rrvalues in rvalues)
                {
                 // Mapping
                    RegistryDetails rDetails= new RegistryDetails()
                    {                   
                        UUID = Guid.NewGuid(),    
                        AgentDeviceuuid = rrvalues.AgentDeviceuuid,
                        Hive = rrvalues.Hive,
                        Key = rrvalues.Key,
                        Value = rrvalues.Value,                 
                        Lastpolled = DateTime.Now   
                    };
                
               _context.RegistryDetails.Add(rDetails);              
            
                }
               _context.SaveChanges();             
               }
                catch (Exception error) {
             
                return BadRequest(error);
            }

              return Ok();            
             
        }
    }
}