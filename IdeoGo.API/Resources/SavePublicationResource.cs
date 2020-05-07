using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class SavePublicationResource
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }


        [MaxLength(150)]
        public string Description { get; set; }

        [Required]
        [MaxLength(300)]
        public string Body { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
