
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
        public class AgentDevicesController : Controller
        {
         private readonly EMSDBContext _context;
         //EMSDBContext _context = new EMSDBContext();
         public AgentDevicesController(EMSDBContext context)
        {
            _context = context;
            
        }
         /// <summary>
        /// List all ComputerInfo (Devices)
        /// </summary>

        [HttpGet]
        [Route("GetDeviceInfo")]
      
        public  IActionResult GetDeviceInfo()
        {     
            try{
                     var joined = (from ad in _context.AgentDevices.AsEnumerable()
                          join hw in (from p in _context.HardwareDetails.OrderByDescending(x => x.LastCollectedDate).AsEnumerable()
                                      group p by p.AgentDeviceuuid into g
                                      select (g.FirstOrDefault()))
                          on ad.UUID equals hw.AgentDeviceuuid
                          select new
                          { 
                              UUID = ad.UUID,
                              AgentDeviceuuid = hw.AgentDeviceuuid,
                              IPAddress = _context.IPAddressDetails.Where(x=> x.AgentDeviceuuid == hw.UUID).FirstOrDefault().IPAddress,
                              UserName = hw.UserName,
                              DomainName = hw.DomainName,
                              ComputerName = ad.ComputerName,
                              BIOSName = hw.BIOSName,
                              BIOSManufacturer = hw.BIOSManufacturer,
                              BIOSVersion = hw.BIOSVersion,
                              BIOSSN = hw.BIOSName,
                              OperatingSystem = hw.OperatingSystem,
                              OSMajorVersion = hw.OSMajorVersion,
                              OSMinorVersion = hw.OSMinorVersion,
                              OSInstallDate = hw.OSInstallDate,
                              LastCollectedDate = hw.LastCollectedDate,
                              ProcessorName = hw.ProcessorName,                             
                              ProcessorCores = hw.ProcessorCores,
                              Memory = hw.Memory
                          }).ToList(); ;
                  return Ok(joined);
            }
             catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
                          
               
        }
        // GET api/values/5
        [HttpGet]
        [Route("{compname}")]
        public async Task<IActionResult> GetDeviceInfoI(String compname)
        {           

           try {            
               
                var checkdevices =  _context.AgentDevices.Where(c => c.ComputerName == compname).Any();
                 if (checkdevices == false){                    
                    AgentDevices agg = new AgentDevices()
                    {
                     UUID = Guid.NewGuid(),
                    ComputerName = compname                          
                    };
                     _context.AgentDevices.Add(agg);
                      _context.SaveChanges();
                 }              
                var results = await _context.AgentDevices.Where(c => c.ComputerName == compname).FirstOrDefaultAsync();
                return Ok(results.UUID);
            }
            catch (Exception error) {
             
                return BadRequest(error);
            }
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
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}