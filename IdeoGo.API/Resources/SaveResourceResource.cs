using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class SaveResourceResource
    {
        [Required]
        public float Quantity { get; set; }
    }
}
