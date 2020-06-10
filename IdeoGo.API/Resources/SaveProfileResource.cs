using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class SaveProfileResource
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public EGender Gender { get; set; }

        [Required]
        [MaxLength(80)]
        public string Occupation { get; set; }


        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(20)]
        public string TypeUser { get; set; }

    }
}
