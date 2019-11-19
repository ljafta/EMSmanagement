using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class SoftwareDetails
    {
       [Key]
        public Guid UUID { get; set; }
        public Guid AgentDeviceuuid { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string InstallLocation { get; set; }
         public DateTime OSInstallDate { get; set; }
         public string Publisher { get; set; }
         public DateTime Lastpolled { get; set; }
       
    }
}