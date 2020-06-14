using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class SaveMembershipResource
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
