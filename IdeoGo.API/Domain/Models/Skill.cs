using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Skill : Requierement
    {

        public int IdS { get; set; }
        public string DegreesRequired { get; set; }

        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
}
