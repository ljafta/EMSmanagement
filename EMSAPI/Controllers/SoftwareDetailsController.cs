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
    [Route("api/[controller]")]
    [ApiController]
public class SoftwareDetailsController : Controller
    {
        private readonly EMSDBContext _context;
         //EMSDBContext _context = new EMSDBContext();
         public SoftwareDetailsController(EMSDBContext context)
        {
            _context = context;
            
        }

        /// <summary>
       ///test
        /// </summary>
    
// GET api/values/5
        [HttpGet]
        [Route("{uuid}")]
        public async Task<IActionResult> GetSoftwareUUID(Guid uuid)
        {
              
           try {
                var results = await _context.SoftwareDetails.Where(c => c.AgentDeviceuuid == uuid).ToListAsync();
                return Ok(results);
            }
            catch (Exception error) {
             
                return BadRequest(error);
            }
        }

        /// <summary>
        /// List all sofwaredetails
        /// </summary>

        [HttpGet]
        [Route("GetSoftwareInfo")]
        public async Task<IActionResult> GetSoftwareDetails()
        {
           try{
            return Ok(await _context.SoftwareDetails.ToListAsync());
        }
              catch (Exception ex)
            {
                ex.Message.ToString();
                return StatusCode(500, ex);
            }
        }
        

         [HttpPost]
         [Route("CreateSoftWare")]
        public async Task<IActionResult> CreateSoftware([FromBody] List<SoftwareDetails> soft)
        {       
                 try {
                foreach( var softt in soft)
                {
                SoftwareDetails softdetails= new SoftwareDetails()
                {                   
                    UUID = Guid.NewGuid(),   
                    AgentDeviceuuid = softt.AgentDeviceuuid,  
                    Name = softt.Name,
                    Version = softt.Version,
                    InstallLocation =softt.InstallLocation,
                    OSInstallDate = softt.OSInstallDate,
                    Publisher= softt.Publisher,
                    Lastpolled = DateTime.Now              

                };
                
                _context.SoftwareDetails.Add(softdetails); 
                             
                }

              await _context.SaveChangesAsync();
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