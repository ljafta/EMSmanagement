using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
   public class IPAddressDetails
    {
    
    [Key]
    public Guid UUID { get; set; }
     public Guid AgentDeviceuuid { get; set; } 
    public string Description { get; set; }
    public string IPAddress { get; set; }

    }

}