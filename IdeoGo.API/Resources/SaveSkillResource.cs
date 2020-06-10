using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IdeoGo.API.Resources
{
    public class SaveSkillResource
    {
        [Required]
        [MaxLength(30)]
        public string DegreesRequired { get; set; }
    }
}
