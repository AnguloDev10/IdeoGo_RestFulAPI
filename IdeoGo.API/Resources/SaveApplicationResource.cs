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
        public int OrderRequest { get; set; }

        [Required]
        [MaxLength(30)]
        public string State { get; set; }

        [Required]
        public DateTime DateSend { get; set; }
    }
}
