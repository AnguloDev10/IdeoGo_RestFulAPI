using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class SaveProjectResource
    {

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }


        [Required]
        public DateTime DateCreated { get; set; }
    }
}
