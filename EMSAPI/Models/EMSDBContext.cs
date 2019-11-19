using BCXZone_SharedLibrary;
using EMS.Models;
using Microsoft.EntityFrameworkCore;


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace EMS.Models.DatabaseContext
{
    public class EMSDBContext : DbContext
    {
          public EMSDBContext(DbContextOptions<EMSDBContext> options)
            : base(options)
        { }
        
    
        public DbSet<AgentDevices> AgentDevices { get; set; }
        public DbSet<HardwareDetails> HardwareDetails { get; set; }        
        public DbSet<SoftwareDetails> SoftwareDetails { get; set; }
        public DbSet<DiskDetails> DiskDetails { get; set; }
        public DbSet<RegistryDetails> RegistryDetails { get; set; }  
        public DbSet<IPAddressDetails> IPAddressDetails { get; set; } 
              
       

    }
}
