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
        public class DiskDetailsController : Controller
        {
         private readonly EMSDBContext _context;
         //EMSDBContext _context = new EMSDBContext();
         public DiskDetailsController(EMSDBContext context)
        {
            _context = context;
            
        }

         /// <summary>
        /// List Disk Id
        /// </summary>
    
// GET api/values/5
        [HttpGet]
        [Route("{uuid}")]
        public async Task<IActionResult> GetDiskID(Guid uuid)
        {
              
           try {
                var results = await _context.DiskDetails.Where(c => c.AgentDeviceuuid == uuid).ToListAsync();
                return Ok(results);
            }
            catch (Exception error) {
             
                return BadRequest(error);
            } 
        } 
        /// <summary>
        /// List of all Disk Info
        /// </summary>

          [HttpGet]
        [Route("GetDiskInfo")]
        // public IActionResult Getahardware([FromBody] HardwareDetails Devices) 
        public IActionResult GetDiskInfo()
        {
        try{
            return Ok( _context.DiskDetails.ToList());
        }
              catch (Exception ex)
            {
                ex.Message.ToString();
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// Create an Email approval
        /// </summary>
        [HttpPost]
         [Route("CreateDisk")]
        public IActionResult PutEmail([FromBody] DiskDetails Devices) 
               { 
                               
                 // Mapping
                DiskDetails dDetails= new DiskDetails()
                {
                    UUID = Guid.NewGuid(),    
                    AgentDeviceuuid =Devices.AgentDeviceuuid,
                    Name = Devices.Name,
                    Drive = Devices.Drive,
                    UsedSpace = Devices.UsedSpace,                    
                    AvailableFreeSpace= Devices.AvailableFreeSpace,
                    TotalSize = Devices.TotalSize ,
                    DriveFormat = Devices.DriveFormat         
                  
                };
                
               _context.DiskDetails.Add(dDetails);            
            
               _context.SaveChanges();            
                      
                return Ok();
                  
        }
    }
}