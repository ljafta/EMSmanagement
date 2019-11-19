using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class AgentDevices
    {
       [Key]
        public Guid UUID { get; set; }        
        public string ComputerName { get; set; }
       
    }
}
