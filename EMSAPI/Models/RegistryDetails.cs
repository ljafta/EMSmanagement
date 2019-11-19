using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
   public class RegistryDetails
    {
        [Key]
        public Guid UUID { get; set; }
        public Guid AgentDeviceuuid { get; set; }
        //public string Location { get; set; }
        public string Hive	{ get; set; }
         public string Value { get; set; }
        public string Key{ get; set; }   
        public DateTime Lastpolled { get; set; }
        
    }

}