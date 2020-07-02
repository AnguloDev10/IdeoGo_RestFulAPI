using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class SaveMTaskResource
    {

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }


        [MaxLength(150)]
        public string Description { get; set; }
        
        [MaxLength(15)]
        public int ProjectScheduleId { get; set; }


        [MaxLength(15)]
        public int ProjectId { get; set; }
    }
}
