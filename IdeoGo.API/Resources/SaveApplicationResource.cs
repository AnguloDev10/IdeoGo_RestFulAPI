using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IdeoGo.API.Resources
{
    public class SaveApplicationResource
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public DateTime StartAt { get; set; }

        [Required]
        public DateTime EndAt { get; set; }
    }
}
