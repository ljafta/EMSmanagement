using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
   public class HardwareDetails
    {
        [Key]
        public Guid UUID { get; set; }
        public Guid AgentDeviceuuid { get; set; }
        //public string Location { get; set; }
        public string ComputerName { get; set; }
        public string IPAddress { get; set; }
        public string DomainName { get; set; }
        public string UserName { get; set; }
        public string BIOSName	 { get; set; }
        //public string Description { get; set; }
        public string BIOSManufacturer { get; set; }
        public string BIOSVersion { get; set; }
        public string BIOSSN { get; set; }
        public string OperatingSystem { get; set; }
        public string OSMajorVersion { get; set; }
        public string OSMinorVersion { get; set; }
        public DateTime OSInstallDate { get; set; }
        public DateTime LastCollectedDate { get; set; }
        public string ProcessorName { get; set; }
        public string ProcessorClockFrequency { get; set; }
        public string ProcessorCores { get; set; }
        public string Memory { get; set; }
        
    }

}
