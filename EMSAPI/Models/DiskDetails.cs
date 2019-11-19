using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
   public class DiskDetails
    {
        [Key]
        public Guid UUID { get; set; }
        public Guid AgentDeviceuuid { get; set; }
        //public string Location { get; set; }
        public string Name { get; set; }
        public string VolumeLabel { get; set; }
        public string Drive { get; set; }
         public string UsedSpace { get; set; }
     
        public string AvailableFreeSpace { get; set; }
        public string TotalSize { get; set; }
        public string DriveFormat { get; set; }
    }

}
