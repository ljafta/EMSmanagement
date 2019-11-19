using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.Models
{
    public class RegistryManagement
    {
       [Key]
        public Guid UUID { get; set; }        
        public string Type { get; set; }
         public string Location { get; set; }
       
    }
}
