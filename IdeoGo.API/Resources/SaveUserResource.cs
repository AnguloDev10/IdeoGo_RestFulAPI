using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [MaxLength(80)]
        public string Occupation { get; set; }

        [Required]
        [MaxLength(100)]
        public string Experience { get; set; }
    }
}
