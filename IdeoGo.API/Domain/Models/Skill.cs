using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Domain.Models
{
    public class Skill 
    {

        public int Id { get; set; }
        public string DegreesRequired { get; set; }

        public int UserProfileId { get; set; }
        public Profile UserProfile { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}

