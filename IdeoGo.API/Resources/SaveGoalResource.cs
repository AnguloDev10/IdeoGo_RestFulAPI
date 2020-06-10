using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class SaveGoalResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        
        [MaxLength(150)]
        public string Description{ get; set; }
    }
}
