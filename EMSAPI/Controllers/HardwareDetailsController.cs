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
        public class HardwareDetailsController : Controller
        {
         private readonly EMSDBContext _context;
         //EMSDBContext _context = new EMSDBContext();
         public HardwareDetailsController(EMSDBContext context)
        {
            _context = context;
            
        }

         /// <summary>
        /// List all ComputerInfo (Devices)
        /// </summary>

        [HttpGet]
        [Route("GetSummaryInfo")]
        public async Task<IActionResult> GetSummaryInfo()
        {       
                
       try{ 
            return Ok(await _context.HardwareDetails.ToListAsync());
        }
              catch (Exception ex)
            {
                ex.Message.ToString();
                return StatusCode(500, ex);
            }
        }
         /// <summary>
        /// List Hard ID
        /// </summary>

    // GET api/values/5
        [HttpGet]
        [Route("{uuid}")]
        public async Task<IActionResult> GetHardwareID(Guid uuid)
        {
              
           try {
                var results = await _context.HardwareDetails.Where(c => c.AgentDeviceuuid == uuid).FirstOrDefaultAsync();
                return Ok(results);
            }
            catch (Exception error) {
             
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Create an Email approval
        /// </summary>
        [HttpPost]
         [Route("CreateAgent")]
        public IActionResult Getahardware([FromBody] HardwareDetails Devices) 
               {      
              try {
                 // Mapping
                HardwareDetails hardDetails= new HardwareDetails()                
                {                   
                    UUID = Guid.NewGuid(),  
                    AgentDeviceuuid = Devices.AgentDeviceuuid,
                    IPAddress = Devices.IPAddress,
                    UserName = Devices.UserName,                 
                    DomainName = Devices.DomainName,
                    ComputerName =  Devices.ComputerName,              
                    BIOSName = Devices.BIOSName,                  
                    BIOSManufacturer = Devices.BIOSManufacturer,
                    BIOSVersion = Devices.BIOSVersion,
                    BIOSSN = Devices.BIOSName, 
                    OperatingSystem = Devices.OperatingSystem,  
                    OSMajorVersion = Devices.OSMajorVersion,
                    OSMinorVersion = Devices.OSMinorVersion,
                    OSInstallDate = Devices.OSInstallDate,
                    LastCollectedDate = Devices.LastCollectedDate,
                    ProcessorName = Devices.ProcessorName,
                   // ProcessorClockFrequency. = Devices.ProcessorClock,
                    ProcessorCores = Devices.ProcessorCores,
                    Memory = Devices.Memory
                  
                };
                
               _context.HardwareDetails.Add(hardDetails);              
                          
               _context.SaveChanges();       
                return Ok(hardDetails);        
            }
            catch (Exception error) {
             
                return BadRequest(error);
            }
                 
        }
    }
}